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
import { OrderHistoryDetailComponent } from './order-history/order-history-detail/order-history-detail.component';
import { OrderHistoryComponent } from './order-history/order-history.component';
import { OrderHistoryItemComponent } from './order-history/order-history-list/order-history-item/order-history-item.component';
import { OrderHistoryListComponent } from './order-history/order-history-list/order-history-list.component';

@NgModule({
    declarations: [
        OrdersComponent,
        OrderListComponent,
        OrderDetailComponent,
        OrderEditComponent,
        OrderHistoryListComponent,
        OrderHistoryItemComponent,
        OrderHistoryDetailComponent,
        OrderHistoryComponent,
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
