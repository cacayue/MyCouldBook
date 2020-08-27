

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCouldBook.BookListManagement.BookTag;

namespace MyCouldBook.EntityMapper.BookTags
{
    public class BookTagCfg : IEntityTypeConfiguration<BookTag>
    {
        public void Configure(EntityTypeBuilder<BookTag> builder)
        {

			 
      //   builder.ToTable("BookTags", YoYoAbpefCoreConsts.SchemaNames.CMS);
        builder.ToTable("BookTags");

            //可以自定义配置参数内容
			
							//// custom codes
									
							

							//// custom codes end
        }
    }
}


