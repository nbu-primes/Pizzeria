import { Recipe } from '../recipes/recipe.model';
import { Subject, Subscription } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { APP_CONFIG, AppConfig } from '../app-config.module';
import { Ingredient } from '../shared/ingredient.model';

export class OrdersService {
    orderList: Recipe[] = [];
    ingredientsList: Ingredient[] = [];

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
}
