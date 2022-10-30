using Abp.Authorization;
using TCache.Authorization.Roles;
using TCache.Authorization.Users;

namespace TCache.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
