using System.Threading.Tasks;
using Abp.Application.Services;
using TCache.Configuration.Dto;

namespace TCache.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}