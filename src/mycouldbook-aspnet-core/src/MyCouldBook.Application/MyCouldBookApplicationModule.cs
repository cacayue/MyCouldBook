using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCouldBook.Authorization;
using MyCouldBook.CustomDtoAutoMapper;
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
            Configuration.Authorization.Providers.Add<BookTagAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<BookListAuthorizationProvider>();

            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                BookDtoAutoMapper.CreateMappings(config);
                BookTagDtoAutoMapper.CreateMappings(config);
                BookListDtoAutoMapper.CreateMappings(config);
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