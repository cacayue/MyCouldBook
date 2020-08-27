
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using MyCouldBook.BookListManagement.BookList;

namespace MyCouldBook.BookListManagement.BookList.Dtos
{
	/// <summary>
	/// 读取可编辑的Dto
	/// </summary>
    public class GetBookListForEditOutput
    {

        public BookListEditDto BookList { get; set; }

		public ICollection<BookSelectedListDto> Books { get; set; }
	}
}