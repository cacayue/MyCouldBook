using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyCouldBook.Authorization.Roles;
using MyCouldBook.Authorization.Users;
using MyCouldBook.MultiTenancy;

namespace MyCouldBook.EntityFrameworkCore
{
    public class MyCouldBookDbContext : AbpZeroDbContext<Tenant, Role, User, MyCouldBookDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MyCouldBookDbContext(DbContextOptions<MyCouldBookDbContext> options)
            : base(options)
        {
        }
    }
}
