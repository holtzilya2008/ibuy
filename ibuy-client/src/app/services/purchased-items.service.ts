import { Injectable } from '@angular/core';
import { PurchasedItemVM } from '../models/purchased-item-vm';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PurchasedItemsService {

    private selectedItem = new BehaviorSubject<PurchasedItemVM>(null);

    constructor() {
    }

    public getSelectedItem(): Observable<PurchasedItemVM> {
        return this.selectedItem.asObservable();
    }

    public updateSelectedItem(item: PurchasedItemVM): void {
        this.selectedItem.next(item);
    }

}
