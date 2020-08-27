import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import {
  BookListDto,
  BookServiceProxy,
} from './../../../shared/service-proxies/service-proxies';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Component, OnInit, Inject, Injector } from '@angular/core';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '@shared/component-base';
import { CreateOrEditBookComponent } from './create-or-edit-book/create-or-edit-book.component';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styles: ['./books.component.less'],
  animations: [appModuleAnimation()],
})
export class BooksComponent extends PagedListingComponentBase<BookListDto>
  implements OnInit {
  constructor(injector: Injector, private _bookService: BookServiceProxy) {
    super(injector);
  }

  /**
   * 默认获取后端分页数据列表
   * @param request 请求数据参数
   * @param pageNumber  当前页码
   * @param finishedCallback 完成后的回调
   */
  protected fetchDataList(
    request: PagedRequestDto,
    pageNumber: number,
    finishedCallback: Function,
  ): void {
    this._bookService
      .getPagedBooks(
        this.filterText,
        request.sorting,
        request.maxResultCount,
        request.skipCount,
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        }),
      )
      .subscribe(result => {
        this.dataList = result.items;
        this.showPaging(result);
      });
  }

  delete(entityDto: BookListDto): void {
    this._bookService.deleteBook(entityDto.id).subscribe(() => {
      this.refreshGoFirstPage();
      abp.notify.success('信息已删除!');
    });
  }

  batchDelete(): void {
    const selectedCount = this.selectedDataItems.length;
    if (selectedCount <= 0) {
      abp.message.warn('请选择所需要的删除的书籍!');
      return;
    }
    abp.message.confirm('是否确认删除', '删除选中数据', res => {
      if (res) {
        const ids = _.map(this.selectedDataItems, 'id');
        this._bookService.batchDeleteBook(ids).subscribe(() => {
          this.refreshGoFirstPage();
          abp.notify.success('信息已删除!');
        });
      }
    });
  }

  createOrEdit(id?: number): void {
    this.modalHelper
      .static(CreateOrEditBookComponent, { id: id })
      .subscribe(result => {
        if (result) {
          this.refresh();
        }
      });
  }
}
