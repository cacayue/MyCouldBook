

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using MyCouldBook.Authorization;

namespace MyCouldBook.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="BookTagPermissions" /> for all permission names. BookTag
    ///</summary>
    public class BookTagAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public BookTagAuthorizationProvider()
		{

		}

       
        public BookTagAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public BookTagAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了BookTag 的权限。
			var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

			var bookTag = administration.CreateChildPermission(BookTagPermissions.Node , L("BookTag"));
bookTag.CreateChildPermission(BookTagPermissions.Query, L("QueryBookTag"));
bookTag.CreateChildPermission(BookTagPermissions.Create, L("CreateBookTag"));
bookTag.CreateChildPermission(BookTagPermissions.Edit, L("EditBookTag"));
bookTag.CreateChildPermission(BookTagPermissions.Delete, L("DeleteBookTag"));
bookTag.CreateChildPermission(BookTagPermissions.BatchDelete, L("BatchDeleteBookTag"));
bookTag.CreateChildPermission(BookTagPermissions.ExportExcel, L("ExportToExcel"));

			
							//// custom codes
									
							

							//// custom codes end
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyCouldBookConsts.LocalizationSourceName);
		}
    }
}
