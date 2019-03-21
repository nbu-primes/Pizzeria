import { Component, OnInit, OnDestroy, OnChanges } from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';

import { Subscription } from 'rxjs';
import { RecipeService } from 'src/app/recipes/recipe.service';
import { Recipe } from 'src/app/recipes/recipe.model';
@Component({
  selector: 'app-order-edit',
  templateUrl: './order-edit.component.html',
  styleUrls: ['./order-edit.component.less']
})
export class OrderEditComponent implements OnInit, OnDestroy {

  recipeSub: Subscription;
  id: string;
  recipeForm: FormGroup;
  usedIngredients: Set<string> = new Set();
  available: string[] = [
    'Salad',
    'Tomato sauce',
    'Corn',
    'Bacon'
  ];

  constructor(private route: ActivatedRoute,
              private router: Router,
              private recipeService: RecipeService) {
  }

  ngOnInit() {
    this.route.params
      .subscribe((params: Params) => {
        this.id = params['id'];
        this.initForm();
      });

  }

  onSubmit() {
    console.log("edit ", this.recipeForm.value);
    // this.onCancel();
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

    this.recipeSub = this.recipeService.getRecipe(this.id)
              .subscribe((editRecipe: Recipe) => {
                console.log(this.id, editRecipe);
                recipeName = editRecipe.name;
                imagePath = editRecipe.imagePath;
                description = editRecipe.description;

                editRecipe.ingredients
                  .forEach((ing) => {
                    const ingGroup = new FormGroup({
                      'name': new FormControl(ing.name, Validators.required)
                    });
                    ingredients.push(ingGroup);
                  });
              });

    this.recipeForm = new FormGroup({
      // 'name': new FormControl(recipeName, Validators.required),
      // 'imagePath': new FormControl(imagePath, Validators.required),
      // 'description': new FormControl(description, Validators.required),
      'ingredients': ingredients
    });

    // should handle unsubscription by itself
    this.recipeForm.valueChanges
        .subscribe((val) => {
          console.log('changed ', val);
          this.usedIngredients.add(val.name);
          console.log('added ', this.usedIngredients);

        });
  }

  ngOnDestroy() {
    this.recipeSub.unsubscribe();
  }
}
