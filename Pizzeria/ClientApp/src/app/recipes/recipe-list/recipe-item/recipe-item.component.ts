import {Component, Input} from '@angular/core';
import {Recipe} from '../../recipe.model';
import { RecipeService } from '../../recipe.service';

@Component({
  selector: 'app-recipe-item',
  templateUrl: './recipe-item.component.html',
  styleUrls: ['./recipe-item.component.less']
})
export class RecipeItemComponent {
  @Input() recipe: Recipe;
  @Input() index: number;

  constructor(private recipeService: RecipeService){}

  recipeTotalPrice(): number {
    const totalPrice = this.recipeService.calculateRecipePrice(this.recipe);
    return totalPrice;
  }
}
