import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CloudBookListRoutingModule } from './cloud-book-list-routing.module';
import { BooksComponent } from './books/books.component';
import { BookListComponent } from './book-list/book-list.component';

@NgModule({
  declarations: [BooksComponent, BookListComponent],
  imports: [CommonModule, CloudBookListRoutingModule],
})
export class CloudBookListModule {}
