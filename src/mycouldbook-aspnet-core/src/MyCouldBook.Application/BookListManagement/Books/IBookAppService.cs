using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCouldBook.BookListManagement.Books.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCouldBook.BookListManagement.Books
{
    public interface IBookAppService : IApplicationService
    {
        /// <summary>
        /// 分页获取书籍
        /// </summary>
        /// <param name="input">分页查询参数</param>
        /// <returns></returns>
        Task<PagedResultDto<BookListDto>> GetPagedBooks(GetBookInput input);
        /// <summary>
        /// 新增或创建书籍
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateBook(CreateOrUpdateBookInput input);
        /// <summary>
        /// 删除指定书籍
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteBook(EntityDto<long> input);
        /// <summary>
        /// 批量删除书籍
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task BatchDeleteBook(List<long> input);
    }
}
