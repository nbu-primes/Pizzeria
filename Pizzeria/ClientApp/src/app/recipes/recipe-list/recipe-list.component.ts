import {Component, OnInit, OnDestroy} from '@angular/core';
import {Recipe} from '../recipe.model';
import {RecipeService} from '../recipe.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.less']
})
export class RecipeListComponent implements OnInit, OnDestroy {
  recipes: Recipe[];
  recipesSub: Subscription;

  constructor(private recipeService: RecipeService) {
  }

  ngOnInit() {
    this.recipesSub = this.recipeService.getRecipes()
        .subscribe((response: Recipe[]) => {
          this.recipes = response;
        });

    this.recipeService.recipeChanged
      .subscribe((recipes: Recipe[]) => {
        this.recipes = recipes;
      });
  }

  ngOnDestroy() {
    this.recipesSub.unsubscribe();
  }
}
