import {Recipe} from './recipe.model';
import {Subject, Observable} from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { APP_CONFIG, AppConfig } from '../app-config.module';

export class RecipeService {
  recipeChanged = new Subject<Recipe[]>();
  private recipes: Recipe[] = [];

  constructor(private httpClient: HttpClient,
              @Inject(APP_CONFIG) private config: AppConfig) {

  }

  // addRecipe(recipe: Recipe) {
  //   this.recipes.push(recipe);
  //   this.notifyChange();
  // }
  totalPrice(recipe: Recipe): number {
    if (!recipe) {
      return -1;
    }
    let totalPrice = recipe.price;
    for (const ingredient of recipe.ingredients) {
      totalPrice += ingredient.price;
    }
    return totalPrice;
  }

  getRecipes(): Observable<Recipe[]> {
    // return a copy of the array
    return this.httpClient.get<Recipe[]>(this.config.apiEndpoint + '/recipe');
  }

  getRecipe(id: string): Observable<Recipe> {
    return this.httpClient.get<Recipe>(this.config.apiEndpoint + '/recipe/' + id);
  }

  private notifyChange() {
    this.recipeChanged.next(this.recipes);
  }
}

