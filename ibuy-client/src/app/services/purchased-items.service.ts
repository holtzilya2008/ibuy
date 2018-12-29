import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable, of } from 'rxjs';
import { PurchasedItemDTO } from '../contracts/purchased-item-dto';
import { HttpClient } from '@angular/common/http';
import { PurchasedItemVM } from '../models/purchased-item-vm';
import { map } from 'rxjs/operators';
import { delay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PurchasedItemsService {

    private baseUrl = environment.serverUrl + '/api/purchasedItems';

    constructor(private httpClient: HttpClient) {}

    public getPurchasedItems(): Observable<PurchasedItemVM[]> {
        const url = this.baseUrl;
        // return this.httpClient.get<PurchasedItemDTO[]>(url)


        return this.getMockItems().pipe(
            map((dtos: PurchasedItemDTO[]) => dtos.map(dto => new PurchasedItemVM(dto)))
        );
    }


    private getMockItems(): Observable<PurchasedItemDTO[]> {
        const mockItems = [];
        for (let i = 0; i < 6; i++) {
            mockItems.push(
                {
                    id: `${i}A${i}A${i}A${i}`,
                    name: `Item ${i}`,
                    description: `Item ${i} description`
                }
            );
        }
        return of(mockItems).pipe(delay(1000));
    }

}
