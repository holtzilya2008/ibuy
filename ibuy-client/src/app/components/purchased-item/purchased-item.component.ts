import { Component, OnInit, Input } from '@angular/core';
import { PurchasedItemVM } from 'src/app/models/purchased-item-vm';

@Component({
  selector: 'app-purchased-item',
  templateUrl: './purchased-item.component.html',
  styleUrls: ['./purchased-item.component.css']
})
export class PurchasedItemComponent implements OnInit {

    @Input()
    public purchasedItem: PurchasedItemVM;

    constructor() { }

    ngOnInit() {
    }

}
