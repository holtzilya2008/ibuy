import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PurchaseManagerViewComponent } from './components/purchase-manager-view/purchase-manager-view.component';
import { PurchaseItemDetailsComponent } from './components/purchase-item-details/purchase-item-details.component';

const routes: Routes = [
    {
        path: 'purchase-manager',
        component: PurchaseManagerViewComponent,
        children: [
            {
                path: ':id',
                component: PurchaseItemDetailsComponent,
            }
        ]
    },
    { path: '**', redirectTo: 'purchase-manager' },
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {}
