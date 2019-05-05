import { Component, OnInit, OnDestroy } from '@angular/core';
import { OrdersService } from '../order.service';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';
import { OrderHistory } from '../models/order-history-model';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.less']
})
export class OrderHistoryComponent implements OnInit, OnDestroy {

  private httpSub: Subscription;
  public orderHistory: OrderHistory[];

  constructor(private orderService: OrdersService,
              private authService: AuthService) { }

  ngOnInit() {
    if (!this.authService.isAuthenticated()) {
      return;
    }

    const userId = this.authService.getUserInfo()['Id'];
    this.httpSub = this.orderService.getUserOrders(userId)
                      .subscribe((data) => {
                          console.log('received order history ', data);
                          this.orderHistory = data;
                      }, (err) => console.log(err));
  }

  ngOnDestroy() {
    this.httpSub.unsubscribe();
  }

}
