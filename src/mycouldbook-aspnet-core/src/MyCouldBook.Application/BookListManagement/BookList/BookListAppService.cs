
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
using MyCouldBook.BookListManagement.BookList;
using MyCouldBook.BookListManagement.BookList.Dtos;
using MyCouldBook.BookListManagement.BookList.DomainService;
using MyCouldBook.Authorization;

namespace MyCouldBook.BookListManagement.BookList
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///</summary>
    [AbpAuthorize]
    public class BookListAppService : MyCouldBookAppServiceBase, IBookListAppService
    {
         private readonly IRepository<BookList, long>        _bookListRepository;



        private readonly IBookListManager _bookListManager;
        /// <summary>
        /// 构造函数
        ///</summary>
        public BookListAppService(
		IRepository<BookList, long>  bookListRepository
              ,IBookListManager bookListManager       

             )
            {
            _bookListRepository = bookListRepository;
             _bookListManager=bookListManager;


            }


            /// <summary>
                /// 获取的分页列表信息
                ///      </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            [AbpAuthorize(BookListPermissions.Query)]
            public async Task<PagedResultDto<BookListListDto>> GetPaged(GetBookListsInput input)
		{

		    var query = _bookListRepository.GetAll()
                           
                            //模糊搜索书单名称
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.ListName.Contains(input.FilterText))                                                                                      
                            //模糊搜索简介
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.Intro.Contains(input.FilterText))                                                           
			;
			// TODO:根据传入的参数添加过滤条件

			var count = await query.CountAsync();

			var bookListList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

		  var bookListListDtos = ObjectMapper.Map<List<BookListListDto>>(bookListList);

			return new PagedResultDto<BookListListDto>(count,bookListListDtos);
		}


		/// <summary>
		/// 通过指定id获取BookListListDto信息
		/// </summary>
		[AbpAuthorize(BookListPermissions.Query)]
		public async Task<BookListListDto> GetById(EntityDto<long> input)
		{
			var entity = await _bookListRepository.GetAsync(input.Id);

			var dto = ObjectMapper.Map<BookListListDto>(entity);
			return dto;
 		}

		/// <summary>
		/// 获取编辑 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BookListPermissions.Create,BookListPermissions.Edit)]
		public async Task<GetBookListForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetBookListForEditOutput();
BookListEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _bookListRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<BookListEditDto>(entity);
			}
			else
			{
				editDto = new BookListEditDto();
			}
    


            output.BookList = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BookListPermissions.Create,BookListPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateBookListInput input)
		{

			if (input.BookList.Id.HasValue)
			{
				await Update(input.BookList);
			}
			else
			{
				await Create(input.BookList);
			}
		}


		/// <summary>
		/// 新增
		/// </summary>
		[AbpAuthorize(BookListPermissions.Create)]
		protected virtual async Task<BookListEditDto> Create(BookListEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<BookList>(input);
            //调用领域服务
            entity = await _bookListManager.CreateAsync(entity);

            var dto=ObjectMapper.Map<BookListEditDto>(entity);
            return dto;
		}

		/// <summary>
		/// 编辑
		/// </summary>
		[AbpAuthorize(BookListPermissions.Edit)]
		protected virtual async Task Update(BookListEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

		 var entity = await _bookListRepository.GetAsync(input.Id.Value);
          //  input.MapTo(entity);
          //将input属性的值赋值到entity中
             ObjectMapper.Map(input, entity);
            await _bookListManager.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BookListPermissions.Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _bookListManager.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除BookList的方法
		/// </summary>
		[AbpAuthorize(BookListPermissions.BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _bookListManager.BatchDelete(input);
		}




							//// custom codes



							//// custom codes end

    }
}


