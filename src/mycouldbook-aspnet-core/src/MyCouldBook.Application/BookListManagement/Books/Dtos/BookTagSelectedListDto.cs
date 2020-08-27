using MyCouldBook.BookListManagement.BookTag.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCouldBook.BookListManagement.Books.Dtos
{
    public class BookTagSelectedListDto: BookTagListDto
    {
        public bool IsSelected { get; set; }
    }
}
