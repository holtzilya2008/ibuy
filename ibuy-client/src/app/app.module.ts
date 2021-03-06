import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { PurchasedItemComponent } from './components/purchased-item/purchased-item.component';
import { PurchasedItemsListComponent } from './components/purchased-items-list/purchased-items-list.component';
import { PurchasedItemsService } from './services/purchased-items.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatCardModule} from '@angular/material/card';
import { PurchaseManagerViewComponent } from './components/purchase-manager-view/purchase-manager-view.component';
import { HeaderComponent } from './components/header/header.component';
import { PurchaseItemDetailsComponent } from './components/purchase-item-details/purchase-item-details.component';
import { PurchaseItemActionsComponent } from './components/purchase-item-actions/purchase-item-actions.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { AppRoutingModule } from './app-routing.module';
import { PurchasedItemsRepositoryService } from './services/purchased-items-repository.service';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';


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
    MatCardModule,
    MatSnackBarModule,
    MatButtonModule,
    AppRoutingModule,
    MatInputModule,
    ReactiveFormsModule,
    MatIconModule
  ],
  providers: [
    PurchasedItemsService,
    PurchasedItemsRepositoryService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
