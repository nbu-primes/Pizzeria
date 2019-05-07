import {Recipe} from './recipe.model';
import {Subject, Observable} from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { APP_CONFIG, AppConfig } from '../app-config.module';
import { of } from 'rxjs';
import { map, share } from 'rxjs/operators';

export class RecipeService {
  recipeChanged = new Subject<Recipe[]>();
  private recipes: Recipe[] = [];

  cachedRecipes: Recipe[] = null;
  recipesObservable: any = null;

  constructor(private httpClient: HttpClient,
              @Inject(APP_CONFIG) private config: AppConfig) {

  }

  calculateRecipePrice(recipe: Recipe): number {
    if (!recipe) {
      return 0;
    }
    const totalPrice = recipe.ingredients.reduce((acc, curr) => {
      return acc + curr.price;
    }, recipe.price);

    return totalPrice;
  }

  getRecipes(): Observable<Recipe[]> {
    // return a copy of the array
    return this.httpClient.get<Recipe[]>(this.config.apiEndpoint + '/recipe');
  }

  getCachedRecipes(): Observable<Recipe[]> {
    if (this.cachedRecipes) {
      return of(this.cachedRecipes);
    } else if (this.recipesObservable) {
      return this.recipesObservable;
    } else {
      this.recipesObservable = this.httpClient
              .get<Recipe[]>(this.config.apiEndpoint + '/recipe',
                {observe: 'response'})
              .pipe(map(response => {
                      this.recipesObservable = null;
                      if (response.status === 400) {
                        return 'Request failed.';
                      } else if (response.status === 200) {
                        this.cachedRecipes = response.body;
                        return this.cachedRecipes;
                      }
                    }), share());

      return this.recipesObservable;
    }
  }

  getRecipe(id: string): Observable<Recipe> {
    return this.httpClient.get<Recipe>(this.config.apiEndpoint + '/recipe/' + id);
  }

  private notifyChange() {
    this.recipeChanged.next(this.recipes);
  }
}

