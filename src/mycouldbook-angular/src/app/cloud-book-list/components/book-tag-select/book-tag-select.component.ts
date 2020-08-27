import { finalize } from 'rxjs/operators';
import {
  BookTagEditDto,
  BookTagServiceProxy,
  CreateOrUpdateBookTagInput,
} from './../../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/component-base/app-component-base';
import {
  Component,
  OnInit,
  Injector,
  ViewChild,
  EventEmitter,
  Output,
  Input,
} from '@angular/core';
import { NzSelectComponent } from 'ng-zorro-antd';

@Component({
  selector: 'app-book-tag-select',
  templateUrl: './book-tag-select.component.html',
  styleUrls: ['./book-tag-select.component.scss'],
})
export class BookTagSelectComponent extends AppComponentBase implements OnInit {
  isLoading = true;
  listOfTagOptions = [];
  listOfSelectedValue = [];
  constructor(
    injector: Injector,
    private _bookTagService: BookTagServiceProxy,
  ) {
    super(injector);
  }
  @ViewChild('booktagselect', null)
  booktagselect: NzSelectComponent;
  @Output() selectedDataChange = new EventEmitter();
  @Input()
  set tagsSourceData(value: any) {
    this.isLoading = true;
    if (value) {
      this.listOfTagOptions = value;
      this.listOfSelectedValue = [];
      this.listOfTagOptions.forEach(item => {
        if (item.isSelected) {
          this.listOfSelectedValue.push(item.id);
        }
      });
    }
    if (this.selectedDataChange) {
      this.selectedDataChange.emit(this.listOfSelectedValue);
    }
    this.isLoading = false;
  }

  modelChange(): void {
    if (this.selectedDataChange) {
      this.selectedDataChange.emit(this.listOfSelectedValue);
    }
  }

  handleInputConfirm(e): void {
    //过滤已存在的
    const booktagselectValues = this.booktagselect.value;
    for (let index = 0; index < booktagselectValues.length; index++) {
      const element = booktagselectValues[index];
      if (typeof element === 'number') {
        break;
      } else {
        if (this.permission.isGranted('Pages.BookTag.Create')) {
          this.isLoading = true;
          const createOrUpdateDto = new CreateOrUpdateBookTagInput();
          const editDto = new BookTagEditDto();
          editDto.tagName = element;
          createOrUpdateDto.bookTag = editDto;
          this._bookTagService
            .createOrUpdate(createOrUpdateDto)
            .pipe(
              finalize(() => {
                this.isLoading = false;
              }),
            )
            .subscribe(res => {
              const listOfSelectedValue = this.listOfSelectedValue;
              const listTagOptions = this.listOfTagOptions;
              for (
                let selectIndex = 0;
                selectIndex < listOfSelectedValue.length;
                selectIndex++
              ) {
                if (res.tagName === listOfSelectedValue[selectIndex]) {
                  listTagOptions.push(res);
                  listOfSelectedValue[selectIndex] = res.id;
                }
              }
            });
        }
      }
    }
  }

  ngOnInit(): void {}
}
