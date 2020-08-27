using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCouldBook.Authorization;
using MyCouldBook.BookListManagement.Books.Authorization;
using MyCouldBook.BookListManagement.Books.Mapper;
using MyCouldBook.Roles.Dto;
using MyCouldBook.Users.Dto;

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
            //添加书籍权限
            Configuration.Authorization.Providers.Add<BookAuthorizationProvider>();
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                BookMapper.CreateMappings(config);
                config.AddProfile<RoleMapProfile>();
                config.AddProfile<UserMapProfile>();
                config.AddProfile<RoleMapProfile>();
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyCouldBookApplicationModule).GetAssembly());
        }
    }
}