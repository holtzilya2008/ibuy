import { Component, OnInit } from '@angular/core';
import { PurchasedItemVM } from 'src/app/models/purchased-item-vm';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { routerNgProbeToken } from '@angular/router/src/router_module';
import { PurchasedItemsRepositoryService } from 'src/app/services/purchased-items-repository.service';
import { PurchasedItemsService } from 'src/app/services/purchased-items.service';

@Component({
  selector: 'app-purchased-items-list',
  templateUrl: './purchased-items-list.component.html',
  styleUrls: ['./purchased-items-list.component.scss']
})
export class PurchasedItemsListComponent implements OnInit {

    purchasedItems: PurchasedItemVM[];

    constructor(
        private purchasedItemsRepository: PurchasedItemsRepositoryService,
        private purchasedItemsService: PurchasedItemsService,
        private snackBar: MatSnackBar,
        private router: Router ) { }

    ngOnInit() {
        this.purchasedItemsRepository.getAll().subscribe((items) => {
            this.purchasedItems = items;
        });
    }

    onSelect(item: PurchasedItemVM) {
        this.unselectAll();
        item.isSelected = true;
        const id = item.isNew ? 'new' : item.id;
        this.router.navigate(['purchase-manager', id ]);
    }

    private unselectAll() {
        for (const item of this.purchasedItems) {
            if (item.isSelected) {
                item.isSelected = false;
            }
        }
    }

    onDelete(target: PurchasedItemVM) {
        this.purchasedItemsRepository.delete(target.id).subscribe(() => {
            const index = this.purchasedItems.findIndex((item) => item.id === target.id);
            this.purchasedItems.splice(index, 1);
            this.snackBar.open(`${target.name} is removed form purchases list`,'', {
                duration: 3000
            });
        });
    }

}
