

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyCouldBook.BookListManagement.BookTag;

namespace MyCouldBook.BookListManagement.BookTag.Dtos
{
    public class CreateOrUpdateBookTagInput
    {
        [Required]
        public BookTagEditDto BookTag { get; set; }
							
							//// custom codes
									
							

							//// custom codes end
    }
}