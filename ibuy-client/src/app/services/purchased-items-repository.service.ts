import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PurchaseRecordDTO } from '../contracts/purchased-item-dto';
import { PurchasedItemVM } from '../models/purchased-item-vm';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { AddPurchasedRecordDTO } from '../contracts/add-purchased-record-dto';

@Injectable({
  providedIn: 'root'
})
export class PurchasedItemsRepositoryService {

  private baseUrl = environment.serverUrl + '/api/PurchaseRecords';

  constructor(private httpClient: HttpClient) {}

  public getAll(): Observable<PurchasedItemVM[]> {
      const url = this.baseUrl;
      return this.httpClient.get<PurchaseRecordDTO[]>(url).pipe(
          map((dtos: PurchaseRecordDTO[]) => dtos.map(dto => new PurchasedItemVM(dto)))
      );
  }

  public get(id: string): Observable<PurchasedItemVM> {
      const url = `${this.baseUrl}/${id}`;
      return this.httpClient.get<PurchaseRecordDTO>(url).pipe(
          map(dto => new PurchasedItemVM(dto))
      );
  }

  public add(item: AddPurchasedRecordDTO): Observable<PurchasedItemVM> {
      const url = this.baseUrl;
      return this.httpClient.post<PurchaseRecordDTO>(url, item).pipe(
          map(dto => new PurchasedItemVM(dto))
      );
  }

  public update(item: PurchaseRecordDTO): Observable<PurchasedItemVM> {
      const url = this.baseUrl;
      return this.httpClient.put<PurchaseRecordDTO>(url, item).pipe(
          map(dto => new PurchasedItemVM(dto))
      );
  }

  public delete(id: string): Observable<string> {
      const url = `${this.baseUrl}/${id}`;
      return this.httpClient.delete<string>(url);
  }
}
