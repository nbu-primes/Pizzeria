import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/recipes/recipe.model';
import { Subscription } from 'rxjs';
import { ShoppingListService } from 'src/app/shopping-list/shopping-list.service';
import { RecipeService } from 'src/app/recipes/recipe.service';
import { Router, ActivatedRoute } from '@angular/router';
import { OrdersService } from '../order.service';
import { concatMap } from 'rxjs/operators';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.less']
})
export class OrderDetailComponent implements OnInit {

  recipe: Recipe;
  index: number;
  subscription: Subscription;
  isLoaded: boolean;

  constructor(private shoppingListService: ShoppingListService,
              private router: Router,
              private route: ActivatedRoute,
              private ordersService: OrdersService) {
  }

  ngOnInit() {
    this.subscription = this.route.params
      .subscribe(params => {
          this.index = +params['id'];
          const recipe = this.ordersService.getOrder(this.index);
          this.recipe = recipe;
          this.isLoaded = true;
      });
  }

  addToOrdersList(): void {
    this.ordersService.addToOrder(this.recipe);
  }

  onOrderRemove(): void {
    this.ordersService.deleteFromOrder(this.index);
    this.router.navigate(['/orders']);
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

}
