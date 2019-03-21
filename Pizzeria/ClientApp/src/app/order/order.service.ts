import { Recipe } from '../recipes/recipe.model';
import { Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { APP_CONFIG, AppConfig } from '../app-config.module';

export class OrdersService {
    orderList: Recipe[] = [];
    orderChanged = new Subject<Recipe[]>();

    constructor(private httpClient: HttpClient,
                @Inject(APP_CONFIG) private config: AppConfig) {

      // // prepopulate with all recipes for dev purposes
      // this.httpClient.get<Recipe[]>(this.config.apiEndpoint + '/recipe')
      //                .subscribe(recipes => {
      //                  this.orderList = recipes;
      //                  this.orderChanged.next(this.orderList);
      //                 });
    }

    getOrder(index: number): Recipe {
        return this.orderList.slice()[index];
    }

    addToOrder(recipe: Recipe): void {
        if (recipe) {
            this.orderList.push(recipe);
            this.notifyChange();
        }
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
