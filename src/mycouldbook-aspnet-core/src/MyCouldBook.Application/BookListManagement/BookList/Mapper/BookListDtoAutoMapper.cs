
using AutoMapper;
using MyCouldBook.BookListManagement.BookList;
using MyCouldBook.BookListManagement.BookList.Dtos;

namespace MyCouldBook.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置BookList的AutoMapper映射
	/// 前往 <see cref="MyCouldBookApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// BookListDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	internal static class BookListDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <BookList,BookListListDto>();
            configuration.CreateMap <BookListListDto,BookList>();

            configuration.CreateMap <BookListEditDto,BookList>();
            configuration.CreateMap <BookList,BookListEditDto>();

            //// custom codes



            //// custom codes end
        }
	}
}
