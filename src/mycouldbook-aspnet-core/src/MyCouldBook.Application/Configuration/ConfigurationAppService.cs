using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyCouldBook.Configuration.Dto;

namespace MyCouldBook.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyCouldBookAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
