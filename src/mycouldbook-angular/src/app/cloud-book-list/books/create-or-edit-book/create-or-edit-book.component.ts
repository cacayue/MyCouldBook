import {
  Component,
  OnInit,
  Injector,
  Input,
  ViewChild,
  AfterViewInit,
} from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import {
  CreateOrUpdateBookInput,
  BookEditDto,
  BookServiceProxy,
  BookTagSelectedListDto,
} from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'create-or-edit-book',
  templateUrl: './create-or-edit-book.component.html',
  styleUrls: ['create-or-edit-book.component.less'],
})
export class CreateOrEditBookComponent extends ModalComponentBase
  implements OnInit {
  /**
   * 编辑时DTO的id
   */
  id: any;

  entity: BookEditDto = new BookEditDto();

  tags: any;

  selectedTags: any = [];

  /**
   * 构造函数，在此处配置依赖注入
   */
  constructor(injector: Injector, private _bookService: BookServiceProxy) {
    super(injector);
  }

  ngOnInit(): void {
    this.init();
  }

  /**
   * 初始化方法
   */
  init(): void {
    this._bookService.getForEdit(this.id).subscribe(result => {
      this.entity = result.book;
      this.tags = result.bookTags;
    });
  }

  /**
   * 保存方法,提交form表单
   */
  submitForm(): void {
    const input = new CreateOrUpdateBookInput();
    input.book = this.entity;
    input.tagIds = this.selectedTags;
    this.saving = true;

    this._bookService
      .createOrUpdate(input)
      .finally(() => (this.saving = false))
      .pipe(finalize(() => (this.saving = false)))
      .subscribe(() => {
        this.notify.success(this.l('SavedSuccessfully'));
        this.success(true);
      });
  }

  tagSelectChange(data: any[]) {
    this.selectedTags = data;
  }
}
