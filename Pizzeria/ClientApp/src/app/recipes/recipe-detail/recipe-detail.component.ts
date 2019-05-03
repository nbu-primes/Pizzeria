import {Component, OnDestroy, OnInit} from '@angular/core';
import {Recipe} from '../recipe.model';
import {ShoppingListService} from '../../shopping-list/shopping-list.service';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {RecipeService} from '../recipe.service';
import {Subscription} from 'rxjs';
import {concatMap} from 'rxjs/operators';
import { OrdersService } from 'src/app/order/order.service';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.less']
})
export class RecipeDetailComponent implements OnInit, OnDestroy {
  recipe: Recipe;
  index: string;
  subscription: Subscription;
  isLoaded: boolean;

  constructor(private shoppingListService: ShoppingListService,
              private recipeService: RecipeService,
              private route: ActivatedRoute,
              private authService: AuthService,
              private ordersService: OrdersService,
              private router: Router) {
  }

  ngOnInit() {
    this.subscription = this.route.params
    .pipe(concatMap(params => {
        this.index = params['id'];
        return this.recipeService.getRecipe(this.index);
    })).subscribe((recipe: Recipe) => {
            this.recipe = recipe;
            this.isLoaded = true;
    });
  }

  addToOrdersList(): void {
    if (!this.authService.isAuthenticated()) {
        this.router.navigate(['signin']);
        return;
    }

    if (confirm('Are you sure you want to add this pizza to the order list ?')) {
      this.ordersService.addToOrder(this.recipe);
      alert(this.recipe.description + ' added to the Order list !');
    }
  }

  addToShoppingList(): void {
    this.shoppingListService.addIngredients(this.recipe.ingredients);
  }

  isAuthenticated(): boolean {
    return this.authService.isAuthenticated();
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

}
