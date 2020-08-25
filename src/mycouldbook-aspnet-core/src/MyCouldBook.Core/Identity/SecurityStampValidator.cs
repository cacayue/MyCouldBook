using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using MyCouldBook.Authorization.Roles;
using MyCouldBook.Authorization.Users;
using MyCouldBook.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace MyCouldBook.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
         IOptions<SecurityStampValidatorOptions> options,
         SignInManager signInManager,
         ISystemClock systemClock,
         ILoggerFactory loggerFactory)
         : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}