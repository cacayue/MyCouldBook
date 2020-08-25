using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCouldBook.Dtos
{
    public class PagedInputDto : IPagedResultRequest
    {
        [Range(0,int.MaxValue)]
        public int SkipCount { get; set; }
        [Range(1,AppConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        public PagedInputDto()
        {
            this.MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}
