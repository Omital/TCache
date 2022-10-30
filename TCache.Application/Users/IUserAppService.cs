using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using TCache.Roles.Dto;
using TCache.Users.Dto;

namespace TCache.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<GetUsersToTestCacheOutput> GetUsersToTestCache(GetUsersToTestCacheInput input);
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}