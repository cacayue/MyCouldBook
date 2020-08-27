using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyCouldBook.Authorization.Roles;
using MyCouldBook.Authorization.Users;
using MyCouldBook.MultiTenancy;
using MyCouldBook.BookListManagement.Books;
using MyCouldBook.BookListManagement.BookList;
using MyCouldBook.BookListManagement.BookTag;
using MyCouldBook.EntityMapper.Books;
using MyCouldBook.BookListManagement.RelationShipps;

namespace MyCouldBook.EntityFrameworkCore
{
    public class MyCouldBookDbContext : AbpZeroDbContext<Tenant, Role, User, MyCouldBookDbContext>
    {
        /* Define a DbSet for each entity of the application */
        #region 书单功能实体
        public DbSet<Book> Books { get; set; }
        public DbSet<BookList> BookLists { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public DbSet<BookAndBookTag> BookAndBookTags { get; set; }
        public DbSet<BookListAndBook> BookListAndBooks { get; set; }

        #endregion


        public MyCouldBookDbContext(DbContextOptions<MyCouldBookDbContext> options)
            : base(options)
        {
        }

    }
}
