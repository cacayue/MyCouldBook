import { BookTagSelectComponent } from './components/book-tag-select/book-tag-select.component';
import { ImgShowComponent } from './components/img-show/img-show.component';
import { TitleService } from '@delon/theme';
import { LocalizationService } from './../../shared/i18n/localization.service';
import { AbpModule } from '@abp/abp.module';
import { SharedModule } from './../../shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CloudBookListRoutingModule } from './cloud-book-list-routing.module';
import { CreateOrEditBookComponent } from './books/create-or-edit-book/create-or-edit-book.component';
import { BookComponent } from './books/book.component';
import { BookListComponent } from './book-list/book-list.component';
import { BookTagComponent } from './book-tag/book-tag.component';
import { CreateOrEditBookTagComponent } from './book-tag/create-or-edit-book-tag/create-or-edit-book-tag.component';
import { CreateOrEditBookListComponent } from './book-list/create-or-edit-book-list/create-or-edit-book-list.component';
import { BookListSelectComponent } from './components/book-list-select/book-list-select.component';

@NgModule({
  declarations: [
    BookComponent,
    BookListComponent,
    CreateOrEditBookComponent,
    BookTagComponent,
    CreateOrEditBookTagComponent,
    ImgShowComponent,
    BookTagSelectComponent,
    CreateOrEditBookListComponent,
    BookListSelectComponent,
  ],
  imports: [
    CommonModule,
    CloudBookListRoutingModule,
    HttpClientModule,
    SharedModule,
    AbpModule,
  ],
  entryComponents: [
    BookComponent,
    BookListComponent,
    BookTagComponent,
    CreateOrEditBookComponent,
    CreateOrEditBookTagComponent,
    ImgShowComponent,
    BookTagSelectComponent,
    CreateOrEditBookListComponent,
    BookListSelectComponent,
  ],
  providers: [LocalizationService, TitleService],
})
export class CloudBookListModule {}
