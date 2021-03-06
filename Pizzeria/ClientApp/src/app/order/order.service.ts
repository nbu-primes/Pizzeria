import { Caterer } from './models/caterer.model';
import { Additive } from './models/additive.model';
import { Recipe } from '../recipes/recipe.model';
import { Subject, Subscription, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { APP_CONFIG, AppConfig } from '../app-config.module';
import { Ingredient } from '../shared/ingredient.model';
import { Order } from './models/order.model';
import { RecipeService } from '../recipes/recipe.service';
import { OrderHistory } from './models/order-history-model';
import { of } from 'rxjs';
import { map, share } from 'rxjs/operators';
import { AuthService } from '../auth/auth.service';

export class OrdersService {
    order: Order = new Order();

    ingredientsList: Ingredient[] = [];
    additiveList: Additive[] = [];
    catererList: Caterer[] = [];

    userOrderHistory: OrderHistory[] = null;
    userHistoryObservable: any;

    orderChanged = new Subject<Recipe[]>();

    constructor(private httpClient: HttpClient,
                private recipeService: RecipeService,
                private authService: AuthService,
                @Inject(APP_CONFIG) private config: AppConfig) {

      this.authService.onLogout.subscribe(() => {
        this.clearUserHistoryCache();
      });

      // prepopulate with all recipes for dev purposes
      // this.httpClient.get<Recipe[]>(this.config.apiEndpoint + '/recipe')
      //                   .subscribe(recipes => {
      //                       this.order.recipes = recipes;
      //                       this.orderChanged.next(this.order.recipes);
      //                     });
    }

    getOrder(index: number): Recipe {
        return this.order.recipes.slice()[index];
    }

    addToOrder(recipe: Recipe): void {
        if (recipe) {
            const deepCopy = JSON.parse(JSON.stringify(recipe));
            this.order.recipes.push(deepCopy);
            this.notifyChange();
        }
    }

    // cache data - https://blog.fullstacktraining.com/caching-http-requests-with-angular/
    getCachedUserOrderHistory(userId: string): Observable<OrderHistory[]> {
      if (this.userOrderHistory) {
        return of(this.userOrderHistory);
      } else if (this.userHistoryObservable) {
        return this.userHistoryObservable;
      } else {
        this.userHistoryObservable = this.httpClient
                .get<OrderHistory[]>(this.config.apiEndpoint + '/userOrders/' + userId,
                  {observe: 'response'})
                .pipe(map(response => {
                        this.userHistoryObservable = null;
                        if (response.status === 400) {
                          return 'Request failed.';
                        } else if (response.status === 200) {
                          this.userOrderHistory = response.body;
                          return this.userOrderHistory;
                        }
                      }), share());

        return this.userHistoryObservable;
      }
    }

    clearUserHistoryCache() {
      this.userHistoryObservable = null;
      this.userOrderHistory = null;
    }

    loadIngredients(): Subscription {
      return this.httpClient.get<Ingredient[]>(this.config.apiEndpoint + '/ingredient')
                      .subscribe((ingredients: Ingredient[]) => {
                          this.ingredientsList = ingredients;
                      });
    }

    loadAdditives(): Subscription {
        return this.httpClient.get<Additive[]>(this.config.apiEndpoint + '/additives')
                        .subscribe((additives: Additive[]) => {
                            this.additiveList = additives;
                        });
    }

    loadCaterers(): Subscription {
        return this.httpClient.get<Caterer[]>(this.config.apiEndpoint + '/caterers')
                        .subscribe((caterers: Caterer[]) => {
                            this.catererList = caterers;
                        });
    }

    calculateTotalPrice(): number {
      let totalOrder = 0;
      // calc recipes + ingredients
      for (const recipe of this.order.recipes) {
        totalOrder += this.recipeService.calculateRecipePrice(recipe);
      }

      // calc order additives
      const totalAdditives = this.order.orderAdditivesPack
                                      .reduce((acc, curr: any) => {
                                        return acc + (curr.product.price * curr.quantity);
                                      }, 0);

      totalOrder += totalAdditives;
      return totalOrder;
    }

    buildOrder(orderForm: any): Order {
      if (!orderForm) {
        return null;
      }

      const finalOrder = JSON.parse(JSON.stringify(this.order));
      console.log('order form ', orderForm);
      finalOrder.catererId = orderForm.caterer.id;
      finalOrder.address = orderForm.address;
      finalOrder.totalPrice = this.calculateTotalPrice();
      finalOrder.recipes.map((el: Recipe) => {
                                el.isTemplate = false;
                                return el;
                          });

      console.log(finalOrder);
      return finalOrder;
    }

    getIngredients(): Ingredient[] {
      return this.ingredientsList.slice();
    }

    deleteFromOrder(index: number): void {
      this.order.recipes.splice(index, 1);
      this.notifyChange();
    }

    getOrders(): Recipe[] {
        return this.order.recipes.slice();
    }

    getAdditives(): Additive[] {
        return this.additiveList.slice();
    }

    getCaterers(): Caterer[] {
        return this.catererList.slice();
    }

    private notifyChange(): void {
      this.orderChanged.next(this.order.recipes.slice());
  }
}
