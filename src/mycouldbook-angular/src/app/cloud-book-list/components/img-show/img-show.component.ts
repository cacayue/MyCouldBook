import { ModalComponentBase } from '@shared/component-base';
import { Component, OnInit, Injector } from '@angular/core';

@Component({
  selector: 'app-img-show',
  templateUrl: './img-show.component.html',
})
export class ImgShowComponent extends ModalComponentBase implements OnInit {
  imgUrl = '';
  constructor(injector: Injector) {
    super(injector);
  }

  ngOnInit() {}
}
