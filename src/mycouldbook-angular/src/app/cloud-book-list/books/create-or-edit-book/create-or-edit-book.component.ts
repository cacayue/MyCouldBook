import { finalize } from 'rxjs/operators';
import {
  BookServiceProxy,
  CreateOrUpdateBookInput,
  BookEditInput,
} from './../../../../shared/service-proxies/service-proxies';
import { Component, OnInit, Injector } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base';
@Component({
  selector: 'app-create-or-edit-book',
  templateUrl: './create-or-edit-book.component.html',
  styles: [],
})
export class CreateOrEditBookComponent extends ModalComponentBase
  implements OnInit {
  id: any;
  entityDto: BookEditInput = new BookEditInput();
  constructor(injector: Injector, private _bookService: BookServiceProxy) {
    super(injector);
  }

  ngOnInit() {
    this.init();
  }

  init(): void {
    //获取编辑中的实体
    this._bookService.getForEditBook(this.id).subscribe(res => {
      this.entityDto = res.book;
    });
  }
  //保存实体
  submitForm(): void {
    const input = new CreateOrUpdateBookInput();
    input.book = this.entityDto;
    this.saving = true;
    this._bookService
      .createOrUpdateBook(input)
      .pipe(
        finalize(() => {
          this.saving = false;
        }),
      )
      .subscribe(() => {
        abp.notify.success('信息保存成功');
        this.success(true);
      });
  }
}
