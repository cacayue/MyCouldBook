
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
using MyCouldBook.BookListManagement.BookTag;
using MyCouldBook.BookListManagement.BookTag.Dtos;
using MyCouldBook.BookListManagement.BookTag.DomainService;
using MyCouldBook.Authorization;
using Abp.UI;

namespace MyCouldBook.BookListManagement.BookTag
{
    /// <summary>
    /// 应用层服务的接口实现方法
    ///</summary>
    [AbpAuthorize]
    public class BookTagAppService : MyCouldBookAppServiceBase, IBookTagAppService
    {
         private readonly IRepository<BookTag, long>        _bookTagRepository;



        private readonly IBookTagManager _bookTagManager;
        /// <summary>
        /// 构造函数
        ///</summary>
        public BookTagAppService(
		IRepository<BookTag, long>  bookTagRepository
              ,IBookTagManager bookTagManager       

             )
            {
            _bookTagRepository = bookTagRepository;
             _bookTagManager=bookTagManager;


            }


            /// <summary>
                /// 获取的分页列表信息
                ///      </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            [AbpAuthorize(BookTagPermissions.Query)]
            public async Task<PagedResultDto<BookTagListDto>> GetPaged(GetBookTagsInput input)
		{

		    var query = _bookTagRepository.GetAll()
                           
                            //模糊搜索标签名称
                          .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a => a.TagName.Contains(input.FilterText))                                                           
			;
			// TODO:根据传入的参数添加过滤条件

			var count = await query.CountAsync();

			var bookTagList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

		  var bookTagListDtos = ObjectMapper.Map<List<BookTagListDto>>(bookTagList);

			return new PagedResultDto<BookTagListDto>(count,bookTagListDtos);
		}


		/// <summary>
		/// 通过指定id获取BookTagListDto信息
		/// </summary>
		[AbpAuthorize(BookTagPermissions.Query)]
		public async Task<BookTagListDto> GetById(EntityDto<long> input)
		{
			var entity = await _bookTagRepository.GetAsync(input.Id);

			var dto = ObjectMapper.Map<BookTagListDto>(entity);
			return dto;
 		}

		/// <summary>
		/// 获取编辑 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BookTagPermissions.Create,BookTagPermissions.Edit)]
		public async Task<GetBookTagForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetBookTagForEditOutput();
BookTagEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _bookTagRepository.GetAsync(input.Id.Value);
				editDto = ObjectMapper.Map<BookTagEditDto>(entity);
			}
			else
			{
				editDto = new BookTagEditDto();
			}
    


            output.BookTag = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BookTagPermissions.Create,BookTagPermissions.Edit)]
		public async Task<BookTagEditDto> CreateOrUpdate(CreateOrUpdateBookTagInput input)
		{
			var dto = new BookTagEditDto();
			if (input.BookTag.Id.HasValue)
			{
				dto = await Update(input.BookTag);
			}
			else
			{
				dto = await Create(input.BookTag);
			}
			return dto;
		}


		/// <summary>
		/// 新增
		/// </summary>
		[AbpAuthorize(BookTagPermissions.Create)]
		protected virtual async Task<BookTagEditDto> Create(BookTagEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<BookTag>(input);
			if (await CheckForDuplicateName(input.TagName, input.Id.Value))
			{
				throw new UserFriendlyException("标签名称不能重复");
			}
			//调用领域服务
			entity = await _bookTagManager.CreateAsync(entity);

            var dto=ObjectMapper.Map<BookTagEditDto>(entity);
            return dto;
		}

		/// <summary>
		/// 编辑
		/// </summary>
		[AbpAuthorize(BookTagPermissions.Edit)]
		protected virtual async Task<BookTagEditDto> Update(BookTagEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _bookTagRepository.GetAsync(input.Id.Value);
			if (await CheckForDuplicateName(input.TagName, input.Id.Value))
            {
				throw new UserFriendlyException("标签名称不能重复");
            }
            await _bookTagManager.UpdateAsync(entity);
			ObjectMapper.Map(entity, input);
			return input;
		}



		/// <summary>
		/// 删除信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BookTagPermissions.Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
            await _bookTagManager.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除BookTag的方法
		/// </summary>
		[AbpAuthorize(BookTagPermissions.BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
            await _bookTagManager.BatchDelete(input);
		}



		private async Task<bool> CheckForDuplicateName(string name,long id)
        {
			var model = await _bookTagRepository.FirstOrDefaultAsync(a => a.TagName == name);
			if(model == null)
            {
				return false;
            }
			//自己id下的可以重复
			if(model.Id == id)
            {
				return false;
			}
			return true;
        }
    }
}


