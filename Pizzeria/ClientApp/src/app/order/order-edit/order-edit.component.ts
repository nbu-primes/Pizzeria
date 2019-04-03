import { Component, OnInit, OnDestroy} from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import { OrdersService } from '../order.service';
import { Ingredient } from 'src/app/shared/ingredient.model';
import { Recipe } from 'src/app/recipes/recipe.model';
import { RecipeService } from 'src/app/recipes/recipe.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-order-edit',
  templateUrl: './order-edit.component.html',
  styleUrls: ['./order-edit.component.less']
})
export class OrderEditComponent implements OnInit, OnDestroy {
  recipeEdit: Recipe;
  recipeForm: FormGroup;

  formSub: Subscription;

  usedIngredients: Set<string>;
  allIngredients: Ingredient[] = [];

  constructor(private route: ActivatedRoute,
              private router: Router,
              private orderService: OrdersService) {
  }

  ngOnInit() {
    this.usedIngredients = new Set<string>();
    this.allIngredients = this.orderService.getIngredients();
    this.route.params
    .subscribe((params: Params) => {
        const id = +params['id'];

        // works with the reference
        this.recipeEdit = this.orderService.getOrder(id);

        this.initForm();
      });
  }

  onSubmit() {
    console.log('modified recipe ', this.recipeEdit);
    this.onCancel();
  }

  isIngredientUsed(ingredient: string): boolean {
    return this.usedIngredients.has(ingredient);
  }

  onCancel() {
    this.router.navigate(['../'], {relativeTo: this.route});
  }

  onDeleteIngredient(index: number) {
    (<FormArray>(this.recipeForm.get('ingredients'))).removeAt(index);
  }

  onAddIngredient() {
    (<FormArray>this.recipeForm.get('ingredients'))
      .push(new FormGroup({
        'name': new FormControl(null, Validators.required)
      }));
  }

  getControls() {
    return ((<FormArray>this.recipeForm.get('ingredients')).controls);
  }

  private initForm() {
    let recipeName = '';
    let imagePath = '';
    let description = '';
    const ingredients = new FormArray([]);
    recipeName = this.recipeEdit.name;
    imagePath = this.recipeEdit.imagePath;
    description = this.recipeEdit.description;

    // copy ingredients from initial Recipe , to a editable form
    this.recipeEdit.ingredients
      .forEach((ing) => {
        this.usedIngredients.add(ing.name);
        const ingGroup = new FormGroup({
          'name': new FormControl(ing.name, Validators.required)
        });
        ingredients.push(ingGroup);
      });

    this.recipeForm = new FormGroup({
      'ingredients': ingredients
    });

    // should handle unsubscription by itself
    this.formSub = this.recipeForm.valueChanges
        .subscribe((control) => this.onValueChange(control));
  }

  private onValueChange(control: any) {
    this.usedIngredients.clear();
    this.recipeEdit.ingredients = [];
    for (const i of control.ingredients) {
      this.usedIngredients.add(i.name);
      console.log('ingrdient from control ', i);
      const ingredientInfo = (this.allIngredients.find(ing => ing.name === i.name));
      if (ingredientInfo) {
        this.recipeEdit.ingredients.push(ingredientInfo);
      }
    }
  }

  ngOnDestroy(): void {
    this.formSub.unsubscribe();
  }
}
