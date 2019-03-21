import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdersComponent } from './order.component';
import { OrderDetailComponent } from './order-detail/order-detail.component';
import { OrderEditComponent } from './order-edit/order-edit.component';

const routes: Routes = [
    {path: 'orders', component: OrdersComponent,
        children: [
            {path: ':id', component: OrderDetailComponent},
            {path: ':id/edit', component: OrderEditComponent},
    ]},
]

@NgModule({
    imports: [ RouterModule.forChild(routes) ],
    exports: [ RouterModule ]
})
export class OrdersRoutingModule {}
