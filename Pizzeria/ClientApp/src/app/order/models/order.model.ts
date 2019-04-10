import { Additive } from './additive.model';
import { Recipe } from 'src/app/recipes/recipe.model';

export class Order {
  public recipes: Recipe[];
  public orderAdditivesPack: Additive[];
  public cateredId: string;
  public totalPrice: number;
  public address: string;

  constructor() {
    this.recipes = [];
    this.orderAdditivesPack = [];
  }
}
