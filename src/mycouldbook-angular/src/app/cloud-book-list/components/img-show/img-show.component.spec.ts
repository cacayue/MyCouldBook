/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ImgShowComponent } from './img-show.component';

describe('ImgShowComponent', () => {
  let component: ImgShowComponent;
  let fixture: ComponentFixture<ImgShowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImgShowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImgShowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
