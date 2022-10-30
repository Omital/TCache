using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TCache.Configuration.Dto;

namespace TCache.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TCacheAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
