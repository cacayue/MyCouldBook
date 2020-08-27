

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
    /// See <see cref="BookListPermissions" /> for all permission names. BookList
    ///</summary>
    public class BookListAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public BookListAuthorizationProvider()
		{

		}

       
        public BookListAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public BookListAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了BookList 的权限。
			var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

			var bookList = administration.CreateChildPermission(BookListPermissions.Node , L("BookList"));
bookList.CreateChildPermission(BookListPermissions.Query, L("QueryBookList"));
bookList.CreateChildPermission(BookListPermissions.Create, L("CreateBookList"));
bookList.CreateChildPermission(BookListPermissions.Edit, L("EditBookList"));
bookList.CreateChildPermission(BookListPermissions.Delete, L("DeleteBookList"));
bookList.CreateChildPermission(BookListPermissions.BatchDelete, L("BatchDeleteBookList"));
bookList.CreateChildPermission(BookListPermissions.ExportExcel, L("ExportToExcel"));

			
							//// custom codes
									
							

							//// custom codes end
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, MyCouldBookConsts.LocalizationSourceName);
		}
    }
}
