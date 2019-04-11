import { Caterer } from './models/caterer.model';
import { Additive } from './models/additive.model';
import { Component, OnInit, OnDestroy, Inject } from '@angular/core';
import { OrdersService } from './order.service';
import { Subscription } from 'rxjs';
import { Recipe } from '../recipes/recipe.model';
import { RecipeService } from '../recipes/recipe.service';
import { FormGroup, FormArray, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { APP_CONFIG, AppConfig } from '../app-config.module';
import { Order } from './models/order.model';
import { Router } from '@angular/router';

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
              private recipeService: RecipeService,
              private httpClient: HttpClient,
              private router: Router,
              @Inject(APP_CONFIG) private config: AppConfig) { }

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

  getOrderedAdditives(): any[] {
    return this.ordersService.order.orderAdditivesPack.slice();
  }

  getAdditiveControls() {
    return ((<FormArray>this.orderForm.get('additives')).controls);
  }

  calculatePizzaPrice(recipeEdit: Recipe): number {
    if (!recipeEdit) {
      return 0;
    }
    return this.recipeService.calculateRecipePrice(recipeEdit);
  }

  calculateTotalPrice() {
    return this.ordersService.calculateTotalPrice();
  }


  finishOrder() {
    if (confirm('Are you sure you want to complete the Order ?')) {
        const finalOrder = this.ordersService.buildOrder(this.orderForm.value);

        // send to server
        this.httpClient.post(`${this.config.apiEndpoint}/order`, finalOrder)
                .subscribe((response) => {
                  console.log("response: ", response);
                  alert('Order placed successfully');

                  // clear order
                  this.clearOrder();
                  // redirect
                  this.router.navigate(['/', 'recipes']);

                }, (error) => {
                  console.log('error: ', error);
                  if (error.status === 401) {
                    alert('User is unauthorized !');
                  }
                  else if (error.status === 500) {
                    alert('Some error occured when we operated your order !');
                  }
                  else {
                    alert('Some error occured !')
                  }
                });
    }
  }

  onAddAdditive() {
    (<FormArray>this.orderForm.get('additives'))
      .push(new FormGroup({
        'product': new FormControl(null, Validators.required),
        'quantity': new FormControl(1,
                    [Validators.required, Validators.pattern(/^\d*[1-9]\d*$/)]),
      }));
  }

  onDeleteAdditive(index: number) {
    (<FormArray>(this.orderForm.get('additives'))).removeAt(index);
  }

  getAllAdditives(): Additive[] {
    return this.ordersService.getAdditives();
  }

  getAllCaterers(): Caterer[] {
    return this.ordersService.getCaterers();
  }

  private clearOrder() {
    this.orderForm.reset();
    this.ordersService.order = new Order();
  }

  private initForm() {
    this.orderForm = new FormGroup({
      'caterer': new FormControl(null, Validators.required),
      'address': new FormControl(null, Validators.required),
      'additives': new FormArray([])
    });

    this.formSub = this.orderForm.valueChanges
                  .subscribe(control => this.onValueChange(control));
  }

  private onValueChange(control: any): void {
      const additives = [];

      for (const a of control.additives) {
        if (!a || !a.product || !a.product.name) {
          continue;
        }
        additives.push(a);
        // // push it as many times as it was ordered
        // for (let i = 0; i < a.quantity; i++) {
        //   additives.push(a.product);
        // }
      }
      // assign it to the order
      this.ordersService.order.orderAdditivesPack = additives;
  }
}
