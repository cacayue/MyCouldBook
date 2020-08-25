using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyCouldBook.Configuration;
using MyCouldBook.Web;

namespace MyCouldBook.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyCouldBookDbContextFactory : IDesignTimeDbContextFactory<MyCouldBookDbContext>
    {
        public MyCouldBookDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyCouldBookDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyCouldBookDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyCouldBookConsts.ConnectionStringName));

            return new MyCouldBookDbContext(builder.Options);
        }
    }
}
