import { Component, OnInit } from '@angular/core';
import {Product} from "@app/pages/pos/models";

@Component({
  selector: 'app-pos',
  templateUrl: './pos.component.html',
  styleUrls: ['./pos.component.css']
})
export class PosComponent implements OnInit {

  products: Product[] = [{
    order: 1,
    productName: 'Mixing machine',
    sku: 'PVN02',
    unit: 'item',
    qty: 1,
    subTotal: 140000,
    total: 140000
  },{
    order: 2,
    productName: 'Egg mixing machine',
    sku: 'PVN02',
    unit: 'item',
    qty: 1,
    subTotal: 150000,
    total: 150000
  }];
  constructor() { }

  ngOnInit(): void {
  }

}
