import { Component, Injector, OnInit } from '@angular/core';
import * as _ from 'lodash';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '@shared/component-base/paged-listing-component-base';
import {
  BookTagServiceProxy,
  BookTagListDtoPagedResultDto,
  BookTagListDto,
} from '@shared/service-proxies/service-proxies';
import { CreateOrEditBookTagComponent } from './create-or-edit-book-tag/create-or-edit-book-tag.component';

import { finalize } from 'rxjs/operators';

@Component({
  templateUrl: './book-tag.component.html',
  styleUrls: ['./book-tag.component.less'],
  animations: [appModuleAnimation()],
})
export class BookTagComponent extends PagedListingComponentBase<BookTagListDto>
  implements OnInit {
  constructor(
    injector: Injector,
    private _bookTagService: BookTagServiceProxy,
  ) {
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
    this._bookTagService
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
      .static(CreateOrEditBookTagComponent, { id: id })
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
  delete(entity: BookTagListDto): void {
    this._bookTagService.delete(entity.id).subscribe(() => {
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
      '',
      res => {
        if (res) {
          const ids = _.map(this.selectedDataItems, 'id');
          this._bookTagService.batchDelete(ids).subscribe(() => {
            this.refreshGoFirstPage();
            this.notify.success(this.l('SuccessfullyDeleted'));
          });
        }
      },
    );
  }

  /**
   * 导出为Excel表
   */
  //     exportToExcel(): void {
  //    // abp.message.error('已经开发完成测试通过！！！！');
  //     this._bookTagService.getToExcelFile().subscribe(result => {
  //   this._fileDownloadService.downloadTempFile(result);
  // });
  //     }

  //     }
}
