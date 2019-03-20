import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdersComponent } from './order.component';
import { RecipeEditComponent } from '../recipes/recipe-edit/recipe-edit.component';
import { OrderDetailComponent } from './order-detail/order-detail.component';

const routes: Routes = [
    {path: 'orders', component: OrdersComponent,
        children: [
            {path: ':id', component: OrderDetailComponent},
            {path: ':id/edit', component: RecipeEditComponent},
    ]},
]

@NgModule({
    imports: [ RouterModule.forChild(routes) ],
    exports: [ RouterModule ]
})
export class OrdersRoutingModule {}
