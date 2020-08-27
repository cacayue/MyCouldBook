
using AutoMapper;
using MyCouldBook.BookListManagement.Books.Dtos;
using MyCouldBook.BookListManagement.BookTag;
using MyCouldBook.BookListManagement.BookTag.Dtos;

namespace MyCouldBook.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置BookTag的AutoMapper映射
	/// 前往 <see cref="MyCouldBookApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// BookTagDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	internal static class BookTagDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <BookTag,BookTagListDto>();
            configuration.CreateMap <BookTagListDto,BookTag>();

            configuration.CreateMap <BookTagEditDto,BookTag>();
            configuration.CreateMap <BookTag,BookTagEditDto>();

            configuration.CreateMap<BookTag, BookTagSelectedListDto>()
                .ForMember(a => a.IsSelected, option => option.Ignore());
        }
	}
}
