using MyCouldBook.BookListManagement.Books.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCouldBook.BookListManagement.BookList.Dtos
{
    public class BookSelectedListDto: BookListDto
    {
        public bool IsSelected { get; set; }
    }
}

