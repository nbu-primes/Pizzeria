import { Component, OnInit} from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import { OrdersService } from '../order.service';
import { Ingredient } from 'src/app/shared/ingredient.model';

@Component({
  selector: 'app-order-edit',
  templateUrl: './order-edit.component.html',
  styleUrls: ['./order-edit.component.less']
})
export class OrderEditComponent implements OnInit {
  id: number;
  recipeForm: FormGroup;
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
        this.id = +params['id'];
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

    const editRecipe = this.orderService.getOrder(this.id);
    console.log(this.id, editRecipe);
    recipeName = editRecipe.name;
    imagePath = editRecipe.imagePath;
    description = editRecipe.description;

    editRecipe.ingredients
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
    this.recipeForm.valueChanges
        .subscribe((control) => {
          this.usedIngredients.clear();
          for (const i of control.ingredients) {
            this.usedIngredients.add(i.name);
          }
          console.log('added ', this.usedIngredients);
        });
  }
}
