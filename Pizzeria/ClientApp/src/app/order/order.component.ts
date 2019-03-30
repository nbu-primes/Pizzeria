import { Caterer } from './models/caterer.model';
import { Additive } from './models/additive.model';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { OrdersService } from './order.service';
import { Subscription } from 'rxjs';
import { Recipe } from '../recipes/recipe.model';
import { RecipeService } from '../recipes/recipe.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.less']
})
export class OrdersComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(private ordersService: OrdersService,
              private recipeService: RecipeService) { }

  ngOnInit() {
      this.sub = this.ordersService.loadIngredients();
      this.sub = this.ordersService.loadAdditives();
      this.sub = this.ordersService.loadCaterers();
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  getOrderList(): Recipe[] {
    return this.ordersService.getOrders();
  }

  calculatePizzaPrice(recipeEdit: Recipe): number {
    if (!recipeEdit) {
      return -1;
    }
    return this.recipeService.totalPrice(recipeEdit);
  }

  calculateTotalPrice(): number {
    let total = 0;
    const orders: Recipe[] = this.getOrderList();
    for (const order of orders) {
      let orderTotal = order.ingredients.reduce((acc, curr) => {
        return acc + curr.price;
      }, order.price);
      total += orderTotal;
    }
    return total;
  }

  finishOrder() {
    if(confirm('Are you sure you want to complete the Order ?')) {
      console.log('finish order w/ these ', this.ordersService.orderList);
    }
  }

  getAdditiveList(): Additive[]{
    return this.ordersService.getAdditives();
  }

  getCatererList(): Caterer[]{
    return this.ordersService.getCaterers();
  }

}
