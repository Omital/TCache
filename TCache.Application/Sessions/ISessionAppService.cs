using System.Threading.Tasks;
using Abp.Application.Services;
using TCache.Sessions.Dto;

namespace TCache.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
