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
  index: string;
  subscription: Subscription;
  isLoaded: boolean;

  constructor(private shoppingListService: ShoppingListService,
              private recipeService: RecipeService,
              private router: Router,
              private route: ActivatedRoute,
              private ordersService: OrdersService) {
  }

  ngOnInit() {
    this.subscription = this.route.params
    .pipe(concatMap(params => {
        this.index = params['id'];
        return this.recipeService.getRecipe(this.index);
    })).subscribe((recipe: Recipe) => {
            this.recipe = recipe;
            this.isLoaded = true;
           console.log("recipe from nested ", recipe);
    });
  }

  addToOrdersList(): void {
    console.log(this.recipe, ' added to orders list');
    this.ordersService.addToOrder(this.recipe);
  }

  onOrderRemove(): void {
    this.ordersService.deleteFromOrder(this.recipe.id);
    this.router.navigate(['/orders']);
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

}
