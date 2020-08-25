using Abp.Authorization;
using MyCouldBook.Authorization.Roles;
using MyCouldBook.Authorization.Users;

namespace MyCouldBook.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
