import { Component, OnInit } from '@angular/core';
import { PurchasedItemVM } from 'src/app/models/purchased-item-vm';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { routerNgProbeToken } from '@angular/router/src/router_module';
import { PurchasedItemsRepositoryService } from 'src/app/services/purchased-items-repository.service';
import { PurchasedItemsService } from 'src/app/services/purchased-items.service';

@Component({
  selector: 'ib-purchased-items-list',
  templateUrl: './purchased-items-list.component.html',
  styleUrls: ['./purchased-items-list.component.scss']
})
export class PurchasedItemsListComponent implements OnInit {

    purchasedItems: PurchasedItemVM[];
    selectedItem: PurchasedItemVM;

    constructor(
        private purchasedItemsRepository: PurchasedItemsRepositoryService,
        private purchasedItemsService: PurchasedItemsService,
        private snackBar: MatSnackBar,
        private router: Router ) { }

    ngOnInit() {
        this.purchasedItemsService.itemUpdated.subscribe((itemId) => this.refresh(itemId));
        this.refresh();
    }

    refresh(selectedItemId = '') {
        this.purchasedItemsRepository.getAll().subscribe((items) => {
            this.purchasedItems = items;
            if (selectedItemId) {
                const targetItem = this.purchasedItems.find(item => item.id === selectedItemId);
                this.selectItem(targetItem);
            }
        });
    }

    selectAndNavigate(item: PurchasedItemVM) {
        if (this.selectedItem && this.selectedItem.isNew && item !== this.selectedItem) {
            this.purchasedItems.pop();
        }
        this.selectItem(item);
        const id = item.isNew ? 'new' : item.id;
        this.router.navigate(['purchase-manager', id ]);
    }

    private selectItem(item: PurchasedItemVM) {
        this.unselectAll();
        item.isSelected = true;
        this.selectedItem = item;
    }

    private unselectAll() {
        for (const item of this.purchasedItems) {
            if (item.isSelected) {
                item.isSelected = false;
            }
        }
        this.selectedItem = null;
    }

    public onDelete(target: PurchasedItemVM) {
        if (this.selectedItem.isNew) {
            this.purchasedItems.pop();
            this.unselectAllAndHideDetails();
        }
        if (target.isNew) {
            return;
        }
        this.purchasedItemsRepository.delete(target.id).subscribe(() => {
            this.refresh();
            this.snackBar.open(`${target.name} is removed form purchases list`,'', {
                duration: 3000
            });
            this.unselectAllAndHideDetails();
        });
    }

    private unselectAllAndHideDetails() {
        this.unselectAll();
        this.router.navigate(['purchase-manager']);
    }

    onAddClicked() {
        const newVM = new PurchasedItemVM(null, true);
        this.purchasedItems.push(newVM);
        this.selectAndNavigate(newVM);
    }

}
