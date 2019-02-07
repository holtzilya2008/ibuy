import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { PurchasedItemComponent } from './components/purchased-item/purchased-item.component';
import { PurchasedItemsListComponent } from './components/purchased-items-list/purchased-items-list.component';
import { PurchasedItemsService } from './services/purchased-items.service';
import { from } from 'rxjs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatCardModule} from '@angular/material/card';
import { PurchaseManagerViewComponent } from './components/purchase-manager-view/purchase-manager-view.component';
import { HeaderComponent } from './components/header/header.component';
import { PurchaseItemDetailsComponent } from './components/purchase-item-details/purchase-item-details.component';
import { PurchaseItemActionsComponent } from './components/purchase-item-actions/purchase-item-actions.component';

@NgModule({
  declarations: [
    AppComponent,
    PurchasedItemComponent,
    PurchasedItemsListComponent,
    PurchaseManagerViewComponent,
    HeaderComponent,
    PurchaseItemDetailsComponent,
    PurchaseItemActionsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    MatCardModule
  ],
  providers: [
    PurchasedItemsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
