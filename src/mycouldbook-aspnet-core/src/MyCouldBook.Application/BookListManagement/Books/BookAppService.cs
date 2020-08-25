using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.ObjectMapping;
using L._52ABP.Common.Extensions;
using Masuit.Tools;
using Microsoft.EntityFrameworkCore;
using MyCouldBook.BookListManagement.Books.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace MyCouldBook.BookListManagement.Books
{
    public class BookAppService : MyCouldBookAppServiceBase, IBookAppService
    {
        private readonly IRepository<Book,long> _bookRepository;
        private readonly IObjectMapper _objectMapper;

        public BookAppService(IRepository<Book, long> bookRepository
            , IObjectMapper objectMapper)
        {
            _bookRepository = bookRepository;
            _objectMapper = objectMapper;
        }

        private async Task CreateBook(BookEditInput input)
        {
            var entity = _objectMapper.Map<Book>(input);
            await _bookRepository.InsertAsync(entity);
        }

        private async Task UpdateBook(BookEditInput input)
        {
            var entity = await _bookRepository.GetAsync(input.Id.Value);
            if(entity != null)
            {
                _objectMapper.Map(input, entity);
                await _bookRepository.UpdateAsync(entity);
            }
        }

        public async Task BatchDeleteBook(List<long> input)
        {
            await _bookRepository.DeleteAsync(b => input.Contains(b.Id));
        }

        public async Task CreateOrUpdateBook(CreateOrUpdateBookInput input)
        {
            if (!input.Book.Id.HasValue)
            {
                await CreateBook(input.Book);
            }
            else
            {
                await UpdateBook(input.Book);
            }
        }

        public async Task DeleteBook(EntityDto<long> input)
        {
            await _bookRepository.DeleteAsync(input.Id);
        }

        public async Task<PagedResultDto<BookListDto>> GetPagedBooks(GetBookInput input)
        {
            var query = _bookRepository.GetAll().AsNoTracking()
                .WhereIf(!input.FilterText.IsNullOrWhiteSpace(),book=>book.Name.Contains(input.FilterText));
            var count = await query.CountAsync();
            var entityList = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = _objectMapper.Map<List<BookListDto>>(entityList);
            //var entityListDto =  entityList.MapTo<List<BookListDto>>();
            return new PagedResultDto<BookListDto>(count, dtos);
        }
    }
}
