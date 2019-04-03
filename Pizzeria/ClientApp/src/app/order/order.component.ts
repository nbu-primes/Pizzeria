import { Caterer } from './models/caterer.model';
import { Additive } from './models/additive.model';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { OrdersService } from './order.service';
import { Subscription } from 'rxjs';
import { Recipe } from '../recipes/recipe.model';
import { RecipeService } from '../recipes/recipe.service';
import { FormGroup, FormArray, FormControl, Validators } from '@angular/forms';
import { Order } from './models/order.model';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.less']
})
export class OrdersComponent implements OnInit, OnDestroy {
  orderForm: FormGroup;

  dataSub: Subscription[] = [];
  formSub: Subscription;

  constructor(private ordersService: OrdersService,
              private recipeService: RecipeService) { }

  ngOnInit() {
      this.initForm();

      this.dataSub.push(this.ordersService.loadIngredients());
      this.dataSub.push(this.ordersService.loadAdditives());
      this.dataSub.push(this.ordersService.loadCaterers());
  }

  ngOnDestroy() {
    this.dataSub.forEach(s => s.unsubscribe());
    this.formSub.unsubscribe();
  }

  getOrderList(): Recipe[] {
    return this.ordersService.getOrders();
  }

  getOrderedAdditives(): Additive[] {
    return this.ordersService.order.orderAdditives.slice();
  }

  getAdditiveControls() {
    return ((<FormArray>this.orderForm.get('additives')).controls);
  }

  calculatePizzaPrice(recipeEdit: Recipe): number {
    if (!recipeEdit) {
      return -1;
    }
    return this.recipeService.totalPrice(recipeEdit);
  }

  calculateTotalPrice(): number {
    const order: Order = this.ordersService.order;
    let totalOrder = 0;
    // calc recipes
    for (const recipe of order.recipes) {
      totalOrder += this.recipeService.totalPrice(recipe);
    }

    const totalAdditives = order.orderAdditives.reduce((acc, curr) => {
      return acc + curr.price;
    }, 0);

    totalOrder += totalAdditives;

    return totalOrder;
  }



  finishOrder() {
    if (confirm('Are you sure you want to complete the Order ?')) {

    }
  }

  onAddAdditive() {
    (<FormArray>this.orderForm.get('additives'))
      .push(new FormGroup({
        'name': new FormControl(null, Validators.required),
        'quantity': new FormControl(1),
      }));
  }

  onDeleteAdditive(index: number) {
    (<FormArray>(this.orderForm.get('additives'))).removeAt(index);
  }

  getAllAdditives(): Additive[] {
    return this.ordersService.getAdditives();
  }

  getAllCaterers(): Caterer[]{
    return this.ordersService.getCaterers();
  }

  private initForm() {
    const formGroup = new FormGroup({
      'name': new FormControl(),
      'quantity': new FormControl(1)
    });
    const additives = new FormArray([formGroup]);
    this.orderForm = new FormGroup({
      'additives': additives
    });

    this.formSub = this.orderForm.valueChanges
                  .subscribe(control => this.onValueChange(control));
  }

  private onValueChange(control: any): void {
      const additives: Additive[] = [];

      for (const a of control.additives) {
        const foundAdd = this.getAllAdditives().find(el =>  el.name === a.name);
        if (!foundAdd) {
          continue;
        }
        // push it as many times as it was ordered
        for (let i = 0; i < a.quantity; i++) {
          additives.push(foundAdd);
        }
      }
      // assign it to the order
      this.ordersService.order.orderAdditives  = additives.slice();
  }
}
