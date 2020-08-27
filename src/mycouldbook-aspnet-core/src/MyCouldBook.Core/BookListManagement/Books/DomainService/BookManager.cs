

using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using MyCouldBook.BookListManagement.RelationShipps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyCouldBook.BookListManagement.Books.DomainService
{
    /// <summary>
    /// 领域服务层一个模块的核心业务逻辑
    ///</summary>
    public class BookManager :MyCouldBookDomainServiceBase, IBookManager
    {
		
		private readonly IRepository<Book,long> _bookRepository;
        private readonly IRepository<BookAndBookTag, long> _bookAndBookTagRepository;

        /// <summary>
        /// Book的构造方法
        /// 通过构造函数注册服务到依赖注入容器中
        ///</summary>
        public BookManager(IRepository<Book, long> bookRepository,
            IRepository<BookAndBookTag, long> bookAndBookTagRepository)	{
			_bookRepository =  bookRepository;
            _bookAndBookTagRepository = bookAndBookTagRepository;
        }

		 #region 查询判断的业务

        /// <summary>
        /// 返回表达式数的实体信息即IQueryable类型
        /// </summary>
        /// <returns></returns>
        public IQueryable<Book> QueryBooks()
        {
            return _bookRepository.GetAll();
        }

        /// <summary>
        /// 返回即IQueryable类型的实体，不包含EF Core跟踪标记
        /// </summary>
        /// <returns></returns>
        public IQueryable<Book> QueryBooksAsNoTracking()
        {
            return _bookRepository.GetAll().AsNoTracking();
        }

        /// <summary>
        /// 根据Id查询实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Book> FindByIdAsync(long id)
        {
            var entity = await _bookRepository.GetAsync(id);
            return entity;
        }

        /// <summary>
        /// 检查实体是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _bookRepository.GetAll().AnyAsync(a => a.Id == id);
            return result;
        }

        #endregion

		 
		 
        public async Task<Book> CreateAsync(Book entity)
        {
            entity.Id = await _bookRepository.InsertAndGetIdAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(Book entity)
        {
            await _bookRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _bookRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDelete(List<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _bookRepository.DeleteAsync(a => input.Contains(a.Id));
        }

        /// <summary>
        /// 创建书籍与标签关系
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="tagIds"></param>
        /// <returns></returns>
        public async Task CreateBookAndBookTag(long bookId, ICollection<long> tagIds)
        {
            await _bookAndBookTagRepository.DeleteAsync(item=>item.BookId== bookId);
            await CurrentUnitOfWork.SaveChangesAsync();
            var newTagId = new List<long>();
            foreach (var tagId in tagIds)
            {
                if (newTagId.Exists(a=>a == tagId))
                {
                    continue;
                }
                await _bookAndBookTagRepository.InsertAsync(new BookAndBookTag
                {
                    BookId = bookId,
                    TagId = tagId
                });
                newTagId.Add(tagId);
            }
        }

        public async Task<ICollection<BookAndBookTag>> GetBooksByTagId(long? tagId)
        {
            return await _bookAndBookTagRepository.GetAll()
.AsNoTracking().Where(a => a.TagId == tagId).ToListAsync();
}

        public async Task<ICollection<BookAndBookTag>> GetBookTagsByBookId(long? bookId)
        {
            return await _bookAndBookTagRepository.GetAll()
.AsNoTracking().Where(a => a.BookId == bookId).ToListAsync();
        }
    }
}
