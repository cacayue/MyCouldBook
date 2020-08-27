
using Abp.Runtime.Validation;
using MyCouldBook.Dtos;
using MyCouldBook.BookListManagement.BookList;

namespace MyCouldBook.BookListManagement.BookList.Dtos
{
	/// <summary>
	/// 获取的传入参数Dto
	/// </summary>
    public class GetBookListsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
