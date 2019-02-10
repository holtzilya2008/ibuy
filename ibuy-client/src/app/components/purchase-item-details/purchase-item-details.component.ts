import { Component, OnInit } from '@angular/core';
import { PurchasedItemVM } from 'src/app/models/purchased-item-vm';
import { ActivatedRoute } from '@angular/router';
import { PurchasedItemsRepositoryService } from 'src/app/services/purchased-items-repository.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { PurchaseRecordDTO } from 'src/app/contracts/purchased-item-dto';
import { AddPurchasedRecordDTO } from 'src/app/contracts/add-purchased-record-dto';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PurchasedItemsService } from 'src/app/services/purchased-items.service';

@Component({
    selector: 'app-purchase-item-details',
    templateUrl: './purchase-item-details.component.html',
    styleUrls: ['./purchase-item-details.component.scss']
})
export class PurchaseItemDetailsComponent implements OnInit {

    itemId: string;
    isNew: boolean;
    itemForm: FormGroup;

    constructor(private activatedRoute: ActivatedRoute,
                private purchaseItemsService: PurchasedItemsService,
                private purchaseItemsRepository: PurchasedItemsRepositoryService,
                private fb: FormBuilder,
                private snackbar: MatSnackBar) { }

    ngOnInit() {
        this.itemId = null;
        this.initForm();
        const id = this.activatedRoute.snapshot.params.id;
        if (id !== 'new') {
            this.initFromServer(id);
        } else {
            this.isNew = true;
        }
    }

    private initForm() {
        this.itemForm = this.fb.group({
            'name': new FormControl('', [Validators.required, Validators.maxLength(100)]),
            'description': new FormControl('', [Validators.maxLength(5000)])
        })
    }

    private initFromServer(id: string) {
        this.purchaseItemsRepository.get(id).subscribe((vm) => {
            this.itemId = vm.id;
            this.name.setValue(vm.name);
            this.description.setValue(vm.description);
        });
    }

    public get name(): FormControl { return this.itemForm.get('name') as FormControl; }
    public get description(): FormControl { return this.itemForm.get('description') as FormControl; }

    onSave() {
        if (this.isNew) {
            this.addNewItem();
        } else {
            this.updateItem();
        }
    }

    private addNewItem() {
        const dto: AddPurchasedRecordDTO = {
            name: this.name.value,
            description: this.description.value
        };
        this.purchaseItemsRepository.add(dto).subscribe((responseVM) => {
            this.snackbar.open(`${this.name.value}`, 'is successfully added', {
                duration: 5000
            });
            this.itemId = responseVM.id;
            this.isNew = false;
            this.emitUpdated();
        });
    }

    private updateItem() {
        const dto: PurchaseRecordDTO = {
            id: this.itemId,
            name: this.name.value,
            description: this.description.value
        };
        this.purchaseItemsRepository.update(dto).subscribe(() => {
            this.snackbar.open(`${this.name.value}`, 'is successfully updated', {
                duration: 5000
            });
            this.emitUpdated();
        });
    }

    private emitUpdated(): void {
        this.purchaseItemsService.itemUpdated.emit(this.itemId);
    }

}
