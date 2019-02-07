import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseItemDetailsComponent } from './purchase-item-details.component';

describe('PurchaseItemDetailsComponent', () => {
  let component: PurchaseItemDetailsComponent;
  let fixture: ComponentFixture<PurchaseItemDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaseItemDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseItemDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
