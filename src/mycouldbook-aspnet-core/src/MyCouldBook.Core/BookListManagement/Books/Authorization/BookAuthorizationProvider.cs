using Abp.Authorization;
using Abp.Localization;
using MyCouldBook.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCouldBook.BookListManagement.Books.Authorization
{
    public class BookAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var pages = context.GetPermissionOrNull(PermissionNames.Pages)??
                context.CreatePermission(PermissionNames.Pages,L("Pages"));
            var admin = pages.Children.FirstOrDefault(a => a.Name == PermissionNames.Pages_Administrator)??
                pages.CreateChildPermission(PermissionNames.Pages_Administrator, L("Administrator"));
            var entityPermission = admin.CreateChildPermission(BookPermissions.BookManager, L("Page.BookManager"));
            entityPermission.CreateChildPermission(BookPermissions.Query, L("Page.Query"));
            entityPermission.CreateChildPermission(BookPermissions.Create, L("Page.Create"));
            entityPermission.CreateChildPermission(BookPermissions.Edit, L("Page.Edit"));
            entityPermission.CreateChildPermission(BookPermissions.Delete, L("Page.Delete"));
            entityPermission.CreateChildPermission(BookPermissions.BatchDelete, L("Page.BatchDelete"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyCouldBookConsts.LocalizationSourceName);
        }
    }
}
