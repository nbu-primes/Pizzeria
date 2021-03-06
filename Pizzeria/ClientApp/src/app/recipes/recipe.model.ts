import {Ingredient} from '../shared/ingredient.model';

export class Recipe {
  public id: string;
  public price: number;
  public weight: number;

  public name: string;
  public description: string;
  public imagePath: string;
  public ingredients: Ingredient[];
  public isTemplate: boolean;

  constructor(name: string, desc: string, imagePath: string, ingredients: Ingredient[]) {
    this.name = name;
    this.description = desc;
    this.imagePath = imagePath;
    this.ingredients = ingredients;
  }
}
