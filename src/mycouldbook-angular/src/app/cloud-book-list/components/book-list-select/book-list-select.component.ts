import { AppComponentBase } from '@shared/component-base/app-component-base';
import {
  Component,
  OnInit,
  Injector,
  ViewChild,
  Output,
  EventEmitter,
  Input,
} from '@angular/core';
import { BookListServiceProxy } from '@shared/service-proxies/service-proxies';
import { NzSelectComponent } from 'ng-zorro-antd';

@Component({
  selector: 'app-book-list-select',
  templateUrl: './book-list-select.component.html',
  styles: [],
})
export class BookListSelectComponent extends AppComponentBase
  implements OnInit {
  isLoading = true;
  listOfBookOptions = [];
  listOfSelectedValue = [];
  constructor(
    injector: Injector,
    private _bookListService: BookListServiceProxy,
  ) {
    super(injector);
  }
  @ViewChild('booklistselect', null)
  booklistselect: NzSelectComponent;
  @Output() selectedDataChange = new EventEmitter();
  @Input()
  set booksSourceData(value: any) {
    this.isLoading = true;
    if (value) {
      this.listOfBookOptions = value;
      this.listOfSelectedValue = [];
      this.listOfBookOptions.forEach(item => {
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

  ngOnInit(): void {}
}
