import { ImgShowComponent } from './../components/img-show/img-show.component';
import { Component, Injector, OnInit } from '@angular/core';
import * as _ from 'lodash';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '@shared/component-base/paged-listing-component-base';
import {
  BookServiceProxy,
  BookListDtoPagedResultDto,
  BookListDto,
} from '@shared/service-proxies/service-proxies';
import { CreateOrEditBookComponent } from './create-or-edit-book/create-or-edit-book.component';

//import { FileDownloadService } from '@shared/utils/file-download.service';
import { finalize } from 'rxjs/operators';

@Component({
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.less'],
  animations: [appModuleAnimation()],
})
export class BookComponent extends PagedListingComponentBase<BookListDto>
  implements OnInit {
  constructor(injector: Injector, private _bookService: BookServiceProxy) {
    super(injector);
  }

  /**
   * 获取后端数据列表信息
   * @param request 请求的数据的dto 请求必需参数 skipCount: number; maxResultCount: number;
   * @param pageNumber 当前页码
   * @param finishedCallback 完成后回调函数
   */
  protected fetchDataList(
    request: PagedRequestDto,
    pageNumber: number,
    finishedCallback: Function,
  ): void {
    this._bookService
      .getPaged(
        this.filterText,
        request.sorting,
        request.maxResultCount,
        request.skipCount,
      )
      .pipe(finalize(() => finishedCallback()))
      .subscribe(result => {
        this.dataList = result.items;
        this.showPaging(result);
      });
  }

  ngOnInit(): void {
    // 初始化加载表格数据
    this.refresh();
  }

  /**
   * 新增或编辑DTO信息
   * @param id 当前DTO的Id
   */
  createOrEdit(id?: number): void {
    this.modalHelper
      .static(CreateOrEditBookComponent, { id: id })
      .subscribe(result => {
        if (result) {
          this.refresh();
        }
      });
  }

  /**
   * 删除功能
   * @param entity 角色的实体信息
   */
  delete(entity: BookListDto): void {
    this._bookService.delete(entity.id).subscribe(() => {
      /**
       * 刷新表格数据并跳转到第一页（`pageNumber = 1`）
       */
      this.refreshGoFirstPage();
      this.notify.success(this.l('SuccessfullyDeleted'));
    });
  }

  /**
   * 批量删除
   */
  batchDelete(): void {
    const selectCount = this.selectedDataItems.length;
    if (selectCount <= 0) {
      abp.message.warn(this.l('PleaseSelectAtLeastOneItem'));
      return;
    }

    abp.message.confirm(
      this.l('ConfirmDeleteXItemsWarningMessage', selectCount),
      '确认删除',
      res => {
        if (res) {
          const ids = _.map(this.selectedDataItems, 'id');
          this._bookService.batchDelete(ids).subscribe(() => {
            this.refreshGoFirstPage();
            this.notify.success(this.l('SuccessfullyDeleted'));
          });
        }
      },
    );
  }

  imgShow(url: string): void {
    this.modalHelper
      .open(
        ImgShowComponent,
        {
          imgUrl: url,
        },
        'md',
      )
      .subscribe(() => {});
  }

  /**
   * 导出为Excel表
   */
  //     exportToExcel(): void {
  //    abp.message.error('已经开发完成测试通过！！！！');
  //     this._bookService.getToExcelFile().subscribe(result => {
  //   this._fileDownloadService.downloadTempFile(result);
  // });
  //     }

  //     }
}
