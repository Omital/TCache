using System.Threading.Tasks;
using Abp.Application.Services;
using TCache.Authorization.Accounts.Dto;

namespace TCache.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
