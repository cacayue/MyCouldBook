using Abp.Runtime.Validation;
using L._52ABP.Application.Dtos;
using L._52ABP.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCouldBook.BookListManagement.Books.Dtos
{
    public class GetBookInput: PagedSortedAndFilteredInputDto, IShouldNormalize
    {
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}
