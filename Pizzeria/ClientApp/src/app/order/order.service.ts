import { Caterer } from './models/caterer.model';
import { Additive } from './models/additive.model';
import { Recipe } from '../recipes/recipe.model';
import { Subject, Subscription } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { APP_CONFIG, AppConfig } from '../app-config.module';
import { Ingredient } from '../shared/ingredient.model';

export class OrdersService {
    orderList: Recipe[] = [];
    ingredientsList: Ingredient[] = [];
    additiveList: Additive[] = [];
    catererList: Caterer[] = [];

    orderChanged = new Subject<Recipe[]>();
    httpSub: Subscription;

    constructor(private httpClient: HttpClient,
                @Inject(APP_CONFIG) private config: AppConfig) {

      // prepopulate with all recipes for dev purposes
      this.httpClient.get<Recipe[]>(this.config.apiEndpoint + '/recipe')
                        .subscribe(recipes => {
                            this.orderList = recipes;
                            this.orderChanged.next(this.orderList);
                          });
    }

    getOrder(index: number): Recipe {
        return this.orderList.slice()[index];
    }

    addToOrder(recipe: Recipe): void {
        if (recipe) {
            const deepCopy = JSON.parse(JSON.stringify(recipe));
            this.orderList.push(deepCopy);
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

    getIngredients(): Ingredient[] {
      return this.ingredientsList.slice();
    }

    deleteFromOrder(index: number): void {
      this.orderList.splice(index, 1);
      this.notifyChange();
    }

    getOrders(): Recipe[] {
        return this.orderList.slice();
    }

    private notifyChange(): void {
        this.orderChanged.next(this.orderList.slice());
    }

    getAdditives(): Additive[]{
        return this.additiveList;
    }

    getCaterers(): Caterer[]{
        return this.catererList;
    }
}
