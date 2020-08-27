
using AutoMapper;
using MyCouldBook.BookListManagement.BookList.Dtos;
using MyCouldBook.BookListManagement.Books;
using MyCouldBook.BookListManagement.Books.Dtos;

namespace MyCouldBook.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Book的AutoMapper映射
	/// 前往 <see cref="MyCouldBookApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// BookDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	internal static class BookDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Book,BookListDto>();
            configuration.CreateMap <BookListDto,Book>();

            configuration.CreateMap <BookEditDto,Book>();
            configuration.CreateMap <Book,BookEditDto>();
            configuration.CreateMap <Book, BookSelectedListDto>();

            //// custom codes



            //// custom codes end
        }
	}
}
