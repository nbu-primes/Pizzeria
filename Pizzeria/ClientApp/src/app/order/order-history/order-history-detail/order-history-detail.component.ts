import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { OrderHistory } from '../../models/order-history-model';
import { OrdersService } from '../../order.service';
import { AuthService } from 'src/app/auth/auth.service';
import { Recipe } from 'src/app/recipes/recipe.model';

@Component({
  selector: 'app-order-history-detail',
  templateUrl: './order-history-detail.component.html',
  styleUrls: ['./order-history-detail.component.less']
})
export class OrderHistoryDetailComponent implements OnInit, OnDestroy {

  private subscription: Subscription;
  orderHistory: OrderHistory;
  constructor(private orderService: OrdersService,
              private authService: AuthService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    if (!this.authService.isAuthenticated()){
        return;
    }

    const userId = this.authService.getUserInfo()['Id'];
    this.subscription = this.route.params
      .subscribe(params => {
          const index = +params['index'];
          this.subscription = this.orderService.getCachedUserOrderHistory(userId)
                                .subscribe((userHistory: OrderHistory[]) => {
                                  this.orderHistory = userHistory[index];
                                });
      });
  }

  ngOnDestroy() {
    if (this.subscription) {
        this.subscription.unsubscribe();
      }
  }

  getIngredients(recipe: Recipe): String {
      return recipe.ingredients.map(i => i.name).join(', ');
  }
}
