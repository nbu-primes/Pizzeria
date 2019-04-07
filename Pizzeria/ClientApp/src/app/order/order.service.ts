import { Caterer } from './models/caterer.model';
import { Additive } from './models/additive.model';
import { Recipe } from '../recipes/recipe.model';
import { Subject, Subscription } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { APP_CONFIG, AppConfig } from '../app-config.module';
import { Ingredient } from '../shared/ingredient.model';
import { Order } from './models/order.model';
import { RecipeService } from '../recipes/recipe.service';

export class OrdersService {
    order: Order = new Order();
    ingredientsList: Ingredient[] = [];
    additiveList: Additive[] = [];
    catererList: Caterer[] = [];

    orderChanged = new Subject<Recipe[]>();
    httpSub: Subscription;

    constructor(private httpClient: HttpClient,
                private recipeService: RecipeService,
                @Inject(APP_CONFIG) private config: AppConfig) {

      // prepopulate with all recipes for dev purposes
      this.httpClient.get<Recipe[]>(this.config.apiEndpoint + '/recipe')
                        .subscribe(recipes => {
                            this.order.recipes = recipes;
                            this.orderChanged.next(this.order.recipes);
                          });
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
      // calc recipes
      for (const recipe of this.order.recipes) {
        totalOrder += this.recipeService.totalPrice(recipe);
      }

      const totalAdditives = this.order.orderAdditives.reduce((acc, curr) => {
        return acc + curr.price;
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

      // transform orderaddtivies , now they come as {product, quantity}
      for (const orderedAddt of orderForm.additives) {
        const addt = orderedAddt.product;
        finalOrder.orderAdditives.push(addt);

        // // don't duplicate them for now.
        // const quantity = orderedAddt.quantity;
        // if (!addt) {
        //   continue;
        // }
        // for (let i = 0; i < quantity; i++) {
        //   finalOrder.orderAdditives.push(addt);
        // }
      }

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
