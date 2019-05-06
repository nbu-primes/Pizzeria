import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { OrderHistory } from '../../models/order-history-model';
import { AuthService } from 'src/app/auth/auth.service';
import { OrdersService } from '../../order.service';

@Component({
  selector: 'app-order-history-list',
  templateUrl: './order-history-list.component.html',
  styleUrls: ['./order-history-list.component.less']
})
export class OrderHistoryListComponent implements OnInit, OnDestroy {

  private httpSub: Subscription;
  public userHistoryList: OrderHistory[];

  constructor(private orderService: OrdersService,
              private authService: AuthService) { }

  ngOnInit() {
    if (!this.authService.isAuthenticated()) {
      return;
    }
    const index = this.authService.getUserInfo()['Id'];
    this.httpSub = this.orderService.getUserOrderHistory(index)
                    .subscribe((userOrders: OrderHistory[]) => {
                      this.userHistoryList = userOrders;
                    });
  }

  ngOnDestroy() {
    if (this.httpSub) {
      this.httpSub.unsubscribe();
    }
  }
}
