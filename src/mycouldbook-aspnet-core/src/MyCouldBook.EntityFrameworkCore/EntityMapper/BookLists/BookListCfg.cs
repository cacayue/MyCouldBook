

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCouldBook.BookListManagement.BookList;

namespace MyCouldBook.EntityMapper.BookLists
{
    public class BookListCfg : IEntityTypeConfiguration<BookList>
    {
        public void Configure(EntityTypeBuilder<BookList> builder)
        {

			 
      //   builder.ToTable("BookLists", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("BookLists");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


