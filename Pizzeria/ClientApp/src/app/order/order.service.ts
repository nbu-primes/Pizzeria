import { Recipe } from '../recipes/recipe.model';
import { Subject } from 'rxjs';

export class OrdersService {
    orderList: Recipe[] = [];

    orderChanged = new Subject<Recipe[]>();

    addToOrder(recipe: Recipe){
        if(recipe){
            this.orderList.push(recipe);
            this.notifyChange();
        }
    }

    getOrders():Recipe[] {
        return this.orderList.slice();
    }

    private notifyChange(): void {
        this.orderChanged.next(this.orderList.slice());
      }
}