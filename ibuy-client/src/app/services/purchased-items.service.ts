import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PurchasedItemsService {

    public itemUpdated = new EventEmitter<string>();

    constructor() {
    }

}
