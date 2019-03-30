[1mdiff --git a/Pizzeria/ClientApp/src/app/order/order.component.ts b/Pizzeria/ClientApp/src/app/order/order.component.ts[m
[1mindex 6c5a080..8c3058f 100644[m
[1m--- a/Pizzeria/ClientApp/src/app/order/order.component.ts[m
[1m+++ b/Pizzeria/ClientApp/src/app/order/order.component.ts[m
[36m@@ -12,19 +12,19 @@[m [mimport { RecipeService } from '../recipes/recipe.service';[m
   styleUrls: ['./order.component.less'][m
 })[m
 export class OrdersComponent implements OnInit, OnDestroy {[m
[31m-  sub: Subscription;[m
[32m+[m[32m  sub: Subscription[] = [];[m
 [m
   constructor(private ordersService: OrdersService,[m
               private recipeService: RecipeService) { }[m
 [m
   ngOnInit() {[m
[31m-      this.sub = this.ordersService.loadIngredients();[m
[31m-      this.sub = this.ordersService.loadAdditives();[m
[31m-      this.sub = this.ordersService.loadCaterers();[m
[32m+[m[32m      this.sub.push(this.ordersService.loadIngredients());[m
[32m+[m[32m      this.sub.push(this.ordersService.loadAdditives());[m
[32m+[m[32m      this.sub.push(this.ordersService.loadCaterers());[m
   }[m
 [m
   ngOnDestroy() {[m
[31m-    this.sub.unsubscribe();[m
[32m+[m[32m    this.sub.forEach(s => s.unsubscribe());[m
   }[m
 [m
   getOrderList(): Recipe[] {[m
