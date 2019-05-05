import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersComponent } from './order.component';
import { OrderListComponent } from './order-list/order-list.component';
import { RecipesModule } from '../recipes/recipes.module';
import { OrdersService } from './order.service';
import { OrdersRoutingModule } from './order-routing.module';
import { OrderDetailComponent } from './order-detail/order-detail.component';
import { SharedModule } from '../shared/shared.module';
import { OrderEditComponent } from './order-edit/order-edit.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrderHistoryComponent } from './order-history/order-history.component';

@NgModule({
    declarations: [
        OrdersComponent,
        OrderListComponent,
        OrderDetailComponent,
        OrderEditComponent,
        OrderHistoryComponent
    ],
    imports: [
        CommonModule,
        OrdersRoutingModule,
        RecipesModule,
        ReactiveFormsModule,
        FormsModule,
        SharedModule
    ],
    providers:[OrdersService]
})
export class OrdersModule {

}
