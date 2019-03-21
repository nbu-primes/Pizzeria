import { Component, OnInit, OnDestroy } from '@angular/core';
import { OrdersService } from './order.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.less']
})
export class OrdersComponent implements OnInit, OnDestroy {

  sub: Subscription;

  constructor(private ordersService: OrdersService) { }
  ngOnInit() {
      this.sub = this.ordersService.loadIngredients();
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
