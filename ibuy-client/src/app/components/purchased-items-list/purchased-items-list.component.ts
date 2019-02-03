import { Component, OnInit } from '@angular/core';
import { PurchasedItemVM } from 'src/app/models/purchased-item-vm';
import { PurchasedItemsService } from 'src/app/services/purchased-items.service';

@Component({
  selector: 'app-purchased-items-list',
  templateUrl: './purchased-items-list.component.html',
  styleUrls: ['./purchased-items-list.component.scss']
})
export class PurchasedItemsListComponent implements OnInit {

    purchasedItems: PurchasedItemVM[];

    constructor(private purchasedItemsService: PurchasedItemsService) { }

    ngOnInit() {
        this.purchasedItemsService.getPurchasedItems().subscribe((items) => {
            this.purchasedItems = items;
        });
    }

    public onAdd() {
        const dto = this.purchasedItemsService.generateMock();
        this.purchasedItemsService.add(dto).subscribe();
    }
}
