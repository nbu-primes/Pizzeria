import { Component, OnInit, OnDestroy } from '@angular/core';
import { OrdersService } from '../order.service';
import { Recipe } from 'src/app/recipes/recipe.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.less']
})
export class OrderListComponent implements OnInit, OnDestroy {

  orderedRecipes: Recipe[];
  orderChangedSub: Subscription;

  constructor(private ordersService: OrdersService) { }

  ngOnInit() {
    this.orderedRecipes = this.ordersService.getOrders();

    this.orderChangedSub = this.ordersService.orderChanged
        .subscribe((updatedOrders: Recipe[]) => {
          this.orderedRecipes = updatedOrders;
        });
  }

  ngOnDestroy(): void {
    if (this.orderChangedSub) {
      this.orderChangedSub.unsubscribe();
    }
  }
}
