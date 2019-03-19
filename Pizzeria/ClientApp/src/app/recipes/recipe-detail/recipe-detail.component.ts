import {Component, OnDestroy, OnInit} from '@angular/core';
import {Recipe} from '../recipe.model';
import {ShoppingListService} from '../../shopping-list/shopping-list.service';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {RecipeService} from '../recipe.service';
import {Subscription} from 'rxjs';
import {concatMap} from 'rxjs/operators';
import { OrdersService } from 'src/app/order/order.service';

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

  addToOrdersList(): void{
    console.log(this.recipe, ' added to orders list');
    this.ordersService.addToOrder(this.recipe);
  }

  addToShoppingList(): void {
    this.shoppingListService.addIngredients(this.recipe.ingredients);
  }

  // onRecipeDelete() {
  //   console.log('delete ', this.index);
  //   this.recipeService.deleteRecipe(this.index);
  //   this.router.navigate(['..'], {relativeTo: this.route});
  // }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

}
