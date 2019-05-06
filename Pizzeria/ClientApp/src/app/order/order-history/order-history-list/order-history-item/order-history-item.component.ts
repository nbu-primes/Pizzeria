import { Component, OnInit, Input } from '@angular/core';
import { OrdersService } from 'src/app/order/order.service';
import { OrderHistory } from 'src/app/order/models/order-history-model';

@Component({
  selector: 'app-order-history-item',
  templateUrl: './order-history-item.component.html',
  styleUrls: ['./order-history-item.component.less']
})
export class OrderHistoryItemComponent implements OnInit {

  @Input() index: number;
  @Input() history: OrderHistory ;

  constructor(private orderService: OrdersService) { }

  ngOnInit() {
    console.log(this.history);
  }

}
