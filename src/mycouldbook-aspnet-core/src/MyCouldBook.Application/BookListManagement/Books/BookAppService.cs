using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.ObjectMapping;
using L._52ABP.Common.Extensions;
using Masuit.Tools;
using Microsoft.EntityFrameworkCore;
using MyCouldBook.BookListManagement.Books.Authorization;
using MyCouldBook.BookListManagement.Books.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace MyCouldBook.BookListManagement.Books
{
    [AbpAuthorize(BookPermissions.BookManager)]
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
        [AbpAuthorize(BookPermissions.Create)]
        private async Task CreateBook(BookEditInput input)
        {
            var entity = _objectMapper.Map<Book>(input);
            await _bookRepository.InsertAsync(entity);
        }
        [AbpAuthorize(BookPermissions.Edit)]
        private async Task UpdateBook(BookEditInput input)
        {
            var entity = await _bookRepository.GetAsync(input.Id.Value);
            if(entity != null)
            {
                _objectMapper.Map(input, entity);
                await _bookRepository.UpdateAsync(entity);
            }
        }
        [AbpAuthorize(BookPermissions.BatchDelete)]
        public async Task BatchDeleteBook(List<long> input)
        {
            await _bookRepository.DeleteAsync(b => input.Contains(b.Id));
        }
        [AbpAuthorize(BookPermissions.Create,BookPermissions.Edit)]
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
        [AbpAuthorize(BookPermissions.Delete)]
        public async Task DeleteBook(EntityDto<long> input)
        {
            await _bookRepository.DeleteAsync(input.Id);
        }
        [AbpAuthorize(BookPermissions.Query)]
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
        [AbpAuthorize(BookPermissions.Edit)]
        public async Task<GetForEditBookOutput> GetForEditBook(NullableIdDto<long> dto)
        {
            BookEditInput entityDto;
            if (dto.Id.HasValue)
            {
                var entity = await _bookRepository.GetAsync(dto.Id.Value);
                entityDto = _objectMapper.Map<BookEditInput>(entity);
            }
            else
            {
                entityDto = new BookEditInput();
            }
            return new GetForEditBookOutput
            {
                book = entityDto
            };
        }
    }
}
