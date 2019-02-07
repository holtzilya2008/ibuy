import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseManagerViewComponent } from './purchase-manager-view.component';

describe('PurchaseManagerViewComponent', () => {
  let component: PurchaseManagerViewComponent;
  let fixture: ComponentFixture<PurchaseManagerViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaseManagerViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseManagerViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
