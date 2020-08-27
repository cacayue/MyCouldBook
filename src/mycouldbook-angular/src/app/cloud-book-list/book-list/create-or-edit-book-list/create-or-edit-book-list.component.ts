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
  CreateOrUpdateBookListInput,
  BookListEditDto,
  BookListServiceProxy,
} from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'create-or-edit-book-list',
  templateUrl: './create-or-edit-book-list.component.html',
  styleUrls: ['create-or-edit-book-list.component.less'],
})
export class CreateOrEditBookListComponent extends ModalComponentBase
  implements OnInit {
  /**
   * 编辑时DTO的id
   */
  id: any;

  entity: BookListEditDto = new BookListEditDto();

  books: any;

  selectedBooks: any = [];

  /**
   * 构造函数，在此处配置依赖注入
   */
  constructor(
    injector: Injector,
    private _bookListService: BookListServiceProxy,
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.init();
  }

  /**
   * 初始化方法
   */
  init(): void {
    this._bookListService.getForEdit(this.id).subscribe(result => {
      this.entity = result.bookList;
      this.books = result.books;
    });
  }

  /**
   * 保存方法,提交form表单
   */
  submitForm(): void {
    const input = new CreateOrUpdateBookListInput();
    input.bookList = this.entity;
    input.bookIds = this.selectedBooks;
    this.saving = true;

    this._bookListService
      .createOrUpdate(input)
      .finally(() => (this.saving = false))
      .pipe(finalize(() => (this.saving = false)))
      .subscribe(() => {
        this.notify.success(this.l('SavedSuccessfully'));
        this.success(true);
      });
  }

  bookSelectChange(data: any[]) {
    this.selectedBooks = data;
  }
}
