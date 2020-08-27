

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyCouldBook.BookListManagement.BookTag.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class BookTagManager :MyCouldBookDomainServiceBase, IBookTagManager
    {
		
		private readonly IRepository<BookTag,long> _bookTagRepository;

		/// <summary>
		/// BookTag的构造方法
		/// 通过构造函数注册服务到依赖注入容器中
		///</summary>
	public BookTagManager(IRepository<BookTag, long> bookTagRepository)	{
			_bookTagRepository =  bookTagRepository;
		}

		 #region 查询判断的业务

        /// <summary>
        /// 返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns></returns>
        public IQueryable<BookTag> QueryBookTags()
        {
            return _bookTagRepository.GetAll();
        }

        /// <summary>
        /// 返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns></returns>
        public IQueryable<BookTag> QueryBookTagsAsNoTracking()
        {
            return _bookTagRepository.GetAll().AsNoTracking();
        }

        /// <summary>
        /// 根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BookTag> FindByIdAsync(long id)
        {
            var entity = await _bookTagRepository.GetAsync(id);
            return entity;
        }

        /// <summary>
        /// 检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _bookTagRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        #endregion

		 
		 
        public async Task<BookTag> CreateAsync(BookTag entity)
        {
            entity.Id = await _bookTagRepository.InsertAndGetIdAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(BookTag entity)
        {
            await _bookTagRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _bookTagRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _bookTagRepository.DeleteAsync(a => input.Contains(a.Id));
        }

        public async Task<List<BookTag>> GetAllBookTags()
        {
            return await _bookTagRepository.GetAll().ToListAsync();
        }

    }
}
