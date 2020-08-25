using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCouldBook.Authorization;
using MyCouldBook.BookListManagement.Books;
using MyCouldBook.BookListManagement.Books.Dtos;
using MyCouldBook.BookListManagement.Books.Mapper;

namespace MyCouldBook
{
    [DependsOn(
        typeof(MyCouldBookCoreModule),
        typeof(AbpAutoMapperModule))]
    public class MyCouldBookApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyCouldBookAuthorizationProvider>();
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                BookMapper.CreateMappings(config);
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyCouldBookApplicationModule).GetAssembly());
        }
    }
}