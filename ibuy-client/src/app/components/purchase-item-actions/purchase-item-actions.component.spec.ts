import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseItemActionsComponent } from './purchase-item-actions.component';

describe('PurchaseItemActionsComponent', () => {
  let component: PurchaseItemActionsComponent;
  let fixture: ComponentFixture<PurchaseItemActionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaseItemActionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseItemActionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
