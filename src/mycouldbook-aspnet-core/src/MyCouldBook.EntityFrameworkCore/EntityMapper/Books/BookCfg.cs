

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCouldBook.BookListManagement.Books;

namespace MyCouldBook.EntityMapper.Books
{
    public class BookCfg : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

			 
      //   builder.ToTable("Books", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("Books");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


