
using Abp.Runtime.Validation;
using MyCouldBook.Dtos;
using MyCouldBook.BookListManagement.Books;

namespace MyCouldBook.BookListManagement.Books.Dtos
{
	/// <summary>
	/// 获取的传入参数Dto
	/// </summary>
    public class GetBooksInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
		
							//// custom codes
									
							

							//// custom codes end
    }
}
