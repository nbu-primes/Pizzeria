import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersComponent } from './order.component';
import { OrderListComponent } from './order-list/order-list.component';
import { RecipesModule } from '../recipes/recipes.module';
import { OrdersService } from './order.service';
import { OrdersRoutingModule } from './order-routing.module';
import { OrderDetailComponent } from './order-detail/order-detail.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    declarations: [
        OrdersComponent,
        OrderListComponent,
        OrderDetailComponent
    ],
    imports: [
        CommonModule,
        OrdersRoutingModule,
        RecipesModule,
        SharedModule
    ],
    providers:[OrdersService]
})
export class OrdersModule {

}
