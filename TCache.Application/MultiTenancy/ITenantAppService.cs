using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TCache.MultiTenancy.Dto;

namespace TCache.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
