using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyCouldBook.Controllers
{
    public abstract class MyCouldBookControllerBase: AbpController
    {
        protected MyCouldBookControllerBase()
        {
            LocalizationSourceName = MyCouldBookConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
