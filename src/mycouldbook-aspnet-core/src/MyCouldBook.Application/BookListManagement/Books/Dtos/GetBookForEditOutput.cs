
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using MyCouldBook.BookListManagement.Books;

namespace MyCouldBook.BookListManagement.Books.Dtos
{
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetBookForEditOutput
    {

        public BookEditDto Book { get; set; }

		public ICollection<BookTagSelectedListDto> BookTags { get; set; }
    }
}