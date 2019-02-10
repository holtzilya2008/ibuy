import { Component, OnInit } from '@angular/core';
import { PurchasedItemVM } from 'src/app/models/purchased-item-vm';
import { ActivatedRoute } from '@angular/router';
import { PurchasedItemsRepositoryService } from 'src/app/services/purchased-items-repository.service';

@Component({
    selector: 'app-purchase-item-details',
    templateUrl: './purchase-item-details.component.html',
    styleUrls: ['./purchase-item-details.component.scss']
})
export class PurchaseItemDetailsComponent implements OnInit {

    name: string;

    constructor(private activatedRoute: ActivatedRoute,
                private purchaseItemsRepository: PurchasedItemsRepositoryService) { }

    ngOnInit() {
        const id = this.activatedRoute.snapshot.params.id;
        console.log(this.activatedRoute);
        if (id === 'new') {
            this.initNew();
        } else {
            this.initFromServer(id);
        }
    }

    private initForm() {

    }

    private initNew() {

    }

    private initFromServer(id: string) {
        this.purchaseItemsRepository.get(id).subscribe((vm) => {
            this.name = vm.name;
        })
    }

}
