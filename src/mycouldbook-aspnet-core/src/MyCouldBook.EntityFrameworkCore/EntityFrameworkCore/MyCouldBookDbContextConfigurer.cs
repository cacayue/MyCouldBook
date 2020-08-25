using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyCouldBook.EntityFrameworkCore
{
    public static class MyCouldBookDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyCouldBookDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyCouldBookDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
