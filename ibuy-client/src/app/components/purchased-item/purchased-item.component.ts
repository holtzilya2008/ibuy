import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PurchasedItemVM } from 'src/app/models/purchased-item-vm';

@Component({
  selector: 'app-purchased-item',
  templateUrl: './purchased-item.component.html',
  styleUrls: ['./purchased-item.component.scss']
})
export class PurchasedItemComponent implements OnInit {

    @Input()
    public purchasedItem: PurchasedItemVM;

    @Output()
    public deleteClicked = new EventEmitter<void>();

    constructor() { }

    ngOnInit() {
    }

    onDelete() {
        this.deleteClicked.emit();
    }

}
