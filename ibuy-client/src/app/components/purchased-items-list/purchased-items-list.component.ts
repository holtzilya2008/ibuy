import { Component, OnInit } from '@angular/core';
import { PurchasedItemVM } from 'src/app/models/purchased-item-vm';
import { PurchasedItemsService } from 'src/app/services/purchased-items.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-purchased-items-list',
  templateUrl: './purchased-items-list.component.html',
  styleUrls: ['./purchased-items-list.component.scss']
})
export class PurchasedItemsListComponent implements OnInit {

    purchasedItems: PurchasedItemVM[];

    constructor(
        private purchasedItemsService: PurchasedItemsService,
        private snackBar: MatSnackBar ) { }

    ngOnInit() {
        this.purchasedItemsService.getAll().subscribe((items) => {
            this.purchasedItems = items;
        });
    }

    onDelete(target: PurchasedItemVM) {
        this.purchasedItemsService.delete(target.id).subscribe(() => {
            const index = this.purchasedItems.findIndex((item) => item.id === target.id);
            this.purchasedItems.splice(index, 1);
            this.snackBar.open(`${target.name} is removed form purchases list`);
        });
    }

}
