import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersComponent } from './order.component';
import { OrderListComponent } from './order-list/order-list.component';
import { RecipesModule } from '../recipes/recipes.module';
import { OrdersService } from './order.service';
import { OrdersRoutingModule } from './order-routing.module';

@NgModule({
    declarations: [
        OrdersComponent,
        OrderListComponent
    ],
    imports: [ 
        CommonModule,
        OrdersRoutingModule,
        RecipesModule
    ],
    providers:[OrdersService]
})
export class OrdersModule {
    
}