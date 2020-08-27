import { TitleService } from '@delon/theme';
import { LocalizationService } from './../../shared/i18n/localization.service';
import { AbpModule } from '@abp/abp.module';
import { SharedModule } from './../../shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CloudBookListRoutingModule } from './cloud-book-list-routing.module';
import { BooksComponent } from './books/books.component';
import { BookListComponent } from './book-list/book-list.component';
import { CreateOrEditBookComponent } from './books/create-or-edit-book/create-or-edit-book.component';

@NgModule({
  declarations: [BooksComponent, BookListComponent, CreateOrEditBookComponent],
  imports: [
    CommonModule,
    CloudBookListRoutingModule,
    HttpClientModule,
    SharedModule,
    AbpModule,
  ],
  entryComponents: [
    BooksComponent,
    BookListComponent,
    CreateOrEditBookComponent,
  ],
  providers: [LocalizationService, TitleService],
})
export class CloudBookListModule {}
