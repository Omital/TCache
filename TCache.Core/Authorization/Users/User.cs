using Abp.Authorization.Users;
using Abp.Extensions;
using Microsoft.AspNet.Identity;
using System;

namespace TCache.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateUser(int tenantId, string userName, string emailAddress, string password)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = userName,
                Name = userName,
                Surname = userName,
                EmailAddress = emailAddress,
                Password = new PasswordHasher().HashPassword(password)
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}