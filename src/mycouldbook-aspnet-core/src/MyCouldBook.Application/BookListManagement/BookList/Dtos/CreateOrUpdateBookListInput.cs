

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyCouldBook.BookListManagement.BookList;

namespace MyCouldBook.BookListManagement.BookList.Dtos
{
    public class CreateOrUpdateBookListInput
    {
        [Required]
        public BookListEditDto BookList { get; set; }

        public ICollection<long> bookIds { get; set; }
    }
}