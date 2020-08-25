using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCouldBook.BookListManagement.Books.Dtos
{
    public class CreateOrUpdateBookInput
    {
        [Required]
        public BookEditInput Book { get; set; }
    }
}
