using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCouldBook.Configuration;

namespace MyCouldBook.Web.Host.Startup
{
    [DependsOn(
       typeof(MyCouldBookWebCoreModule))]
    public class MyCouldBookWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyCouldBookWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyCouldBookWebHostModule).GetAssembly());
        }
    }
}