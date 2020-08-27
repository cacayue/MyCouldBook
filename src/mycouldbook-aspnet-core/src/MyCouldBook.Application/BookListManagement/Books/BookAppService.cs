
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.Domain.Repositories;
using L._52ABP.Application.Dtos;
using L._52ABP.Common.Extensions.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using MyCouldBook.BookListManagement.Books;
using MyCouldBook.BookListManagement.Books.Dtos;
using MyCouldBook.BookListManagement.Books.DomainService;
using MyCouldBook.Authorization;
using MyCouldBook.BookListManagement.RelationShipps;
using MyCouldBook.BookListManagement.BookTag.DomainService;

namespace MyCouldBook.BookListManagement.Books
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///</summary>
    [AbpAuthorize]
    public class BookAppService : MyCouldBookAppServiceBase, IBookAppService
    {
         private readonly IRepository<Book, long> _bookRepository;
         private readonly IRepository<BookAndBookTag, long> _bookAndTagRepository;


		private readonly IBookTagManager _bookTagManager;
		private readonly IBookManager _bookManager;
        /// <summary>
        /// 构造函数
        ///</summary>
        public BookAppService(
		IRepository<Book, long>  bookRepository,
		 IRepository<BookAndBookTag, long> bookAndTagRepository,
		IBookManager bookManager,
		 IBookTagManager bookTagManager
             )
            {
            _bookRepository = bookRepository;
			 _bookManager =bookManager;
			_bookTagManager = bookTagManager;
			_bookAndTagRepository = bookAndTagRepository;
			}


            /// <summary>
                /// 获取的分页列表信息
                ///      </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            [AbpAuthorize(BookPermissions.Query)]
            public async Task<PagedResultDto<BookListDto>> GetPaged(GetBooksInput input)
		{

		    var query = _bookRepository.GetAll()
                           
                            //模糊搜索书籍名称
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Name.Contains(input.FilterText))                                                                                      
                            //模糊搜索作者
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Author.Contains(input.FilterText))                                                                                      
                            //模糊搜索购买链接
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.PriceUrl.Contains(input.FilterText))                                                                                      
                            //模糊搜索封面链接
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ImgUrl.Contains(input.FilterText))                                                                                      
                            //模糊搜索简介
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Intro.Contains(input.FilterText))                                                           
			;
			// TODO:根据传入的参数添加过滤条件

			var count = await query.CountAsync();

			var bookList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

		  var bookListDtos = ObjectMapper.Map<List<BookListDto>>(bookList);

			return new PagedResultDto<BookListDto>(count,bookListDtos);
		}


		/// <summary>
		/// 通过指定id获取BookListDto信息
		/// </summary>
		[AbpAuthorize(BookPermissions.Query)]
		public async Task<BookListDto> GetById(EntityDto<long> input)
		{
			var entity = await _bookRepository.GetAsync(input.Id);

			var dto = ObjectMapper.Map<BookListDto>(entity);
			return dto;
 		}

		/// <summary>
		/// 获取编辑 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BookPermissions.Create,BookPermissions.Edit)]
		public async Task<GetBookForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetBookForEditOutput();
			BookEditDto editDto;
			List<long> allSelectedTagIds = null;
			var allBookTags = ObjectMapper
				.Map<List<BookTagSelectedListDto>>((await _bookTagManager.GetAllBookTags()));
			
			if (input.Id.HasValue)
			{
				var entity = await _bookRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<BookEditDto>(entity);
				allSelectedTagIds = (await _bookManager.GetBookTagsByBookId(editDto.Id)).Select(b=>b.TagId).ToList();
                if (allSelectedTagIds.Count > 0)
                {
					foreach (var bookTag in allBookTags)
					{
						if (allSelectedTagIds.Any(b => b == bookTag.Id))
						{
							bookTag.IsSelected = true;
						}
					}
				}
			}
			else
			{
				editDto = new BookEditDto();
			}
    


            output.Book = editDto;
			output.BookTags = allBookTags;
			return output;
		}


		/// <summary>
		/// 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BookPermissions.Create,BookPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateBookInput input)
		{

			if (input.Book.Id.HasValue)
			{
				await Update(input.Book, input.tagIds);
			}
			else
			{
				await Create(input.Book, input.tagIds);
			}
		}


		/// <summary>
		/// 新增
		/// </summary>
		[AbpAuthorize(BookPermissions.Create)]
		protected virtual async Task<BookEditDto> Create(BookEditDto input, ICollection<long> tagIds)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<Book>(input);
            //调用领域服务
            entity = await _bookManager.CreateAsync(entity);
			if(tagIds.Count> 0)
            {await _bookManager.CreateBookAndBookTag(entity.Id, tagIds);
			}
            var dto=ObjectMapper.Map<BookEditDto>(entity);
            return dto;
		}

		/// <summary>
		/// 编辑
		/// </summary>
		[AbpAuthorize(BookPermissions.Edit)]
		protected virtual async Task Update(BookEditDto input, ICollection<long> tagIds)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _bookRepository.GetAsync(input.Id.Value);
          //  input.MapTo(entity);
          //将input属性的值赋值到entity中
             ObjectMapper.Map(input, entity);
            await _bookManager.UpdateAsync(entity);
			await _bookManager.CreateBookAndBookTag(entity.Id, tagIds);
		}



		/// <summary>
		/// 删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BookPermissions.Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _bookManager.DeleteAsync(input.Id);
			await _bookAndTagRepository.DeleteAsync(a => a.BookId == input.Id);
		}



		/// <summary>
		/// 批量删除Book的方法
		/// </summary>
		[AbpAuthorize(BookPermissions.BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _bookManager.BatchDelete(input);
			await _bookAndTagRepository.DeleteAsync(a => input.Contains(a.BookId));
		}


	}
}


