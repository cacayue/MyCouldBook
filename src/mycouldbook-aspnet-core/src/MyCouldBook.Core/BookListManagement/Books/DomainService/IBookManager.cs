
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;
using MyCouldBook.BookListManagement.RelationShipps;

namespace MyCouldBook.BookListManagement.Books.DomainService
{
    public interface IBookManager : IDomainService
    {


		/// <summary>
		/// 返回表达式数的实体信息即IQueryable类型
		/// </summary>
		/// <returns></returns>
		IQueryable<Book> QueryBooks();

		/// <summary>
		/// 返回性能更好的IQueryable类型，但不包含EF Core跟踪标记
		/// </summary>
		/// <returns></returns>

		IQueryable<Book> QueryBooksAsNoTracking();

		/// <summary>
		/// 根据Id查询实体信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Book> FindByIdAsync(long id);
	
		/// <summary>
		/// 检查实体是否存在
		/// </summary>
		/// <returns></returns>
		Task<bool> IsExistAsync(long id);


		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		Task<Book> CreateAsync(Book entity);

		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		Task UpdateAsync(Book entity);

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteAsync(long id);
		/// <summary>
		/// 批量删除
		/// </summary>
		/// <param name="input">Id的集合</param>
		/// <returns></returns>
		Task BatchDelete(List<long> input);



		/// <summary>
		/// 根据标签获取书籍
		/// </summary>
		/// <param name="tagId">标签ID</param>
		/// <returns></returns>
		Task<ICollection<BookAndBookTag>> GetBooksByTagId(long? tagId);
		/// <summary>
		/// 根据书籍获取标签
		/// </summary>
		/// <param name="bookId"></param>
		/// <returns></returns>
		Task<ICollection<BookAndBookTag>> GetBookTagsByBookId(long? bookId);
		/// <summary>
		/// 创建书籍与标签关系
		/// </summary>
		/// <param name="bookId"></param>
		/// <param name="tagIds"></param>
		/// <returns></returns>
		Task CreateBookAndBookTag(long bookId, ICollection<long> tagIds);
	}
}
