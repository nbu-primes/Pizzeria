import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersComponent } from './order.component';
import { OrderListComponent } from './order-list/order-list.component';
import { RecipesModule } from '../recipes/recipes.module';
import { OrdersService } from './order.service';
import { RecipeItemComponent } from '../recipes/recipe-list/recipe-item/recipe-item.component';

@NgModule({
    declarations: [
        OrdersComponent,
        OrderListComponent
    ],
    imports: [ 
        CommonModule,
        RecipesModule
    ],
    providers:[OrdersService]
})
export class OrdersModule {
    
}