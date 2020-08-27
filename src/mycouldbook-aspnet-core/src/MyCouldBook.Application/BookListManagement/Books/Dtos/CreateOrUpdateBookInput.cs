

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyCouldBook.BookListManagement.Books;

namespace MyCouldBook.BookListManagement.Books.Dtos
{
    public class CreateOrUpdateBookInput
    {
        [Required]
        public BookEditDto Book { get; set; }

        public ICollection<long> tagIds { get; set; }
    }
}