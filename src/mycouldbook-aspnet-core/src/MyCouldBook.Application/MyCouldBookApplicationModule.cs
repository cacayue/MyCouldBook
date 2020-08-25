using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCouldBook.Authorization;

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
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyCouldBookApplicationModule).GetAssembly());
        }
    }
}