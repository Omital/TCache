using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using System.Collections.Generic;
using System.Linq;
using TCache.Authorization;
using TCache.Authorization.Roles;
using TCache.Authorization.Users;
using TCache.EntityFramework;

namespace TCache.Migrations.SeedData
{
    public class TenantRoleAndUserBuilder
    {
        private readonly TCacheDbContext _context;
        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(TCacheDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            //Admin role

            var adminRole = _context.Roles.FirstOrDefault(r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Tenants.Admin);
            if (adminRole == null)
            {
                adminRole = new Role(_tenantId, StaticRoleNames.Tenants.Admin, StaticRoleNames.Tenants.Admin)
                {
                    IsStatic = true
                };

                adminRole.SetNormalizedName();

                _context.Roles.Add(adminRole);
                _context.SaveChanges();

                //Grant all permissions to admin role
                var permissions = PermissionFinder
                    .GetAllPermissions(new TCacheAuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant))
                    .ToList();

                foreach (var permission in permissions)
                {
                    _context.Permissions.Add(
                        new RolePermissionSetting
                        {
                            TenantId = _tenantId,
                            Name = permission.Name,
                            IsGranted = true,
                            RoleId = adminRole.Id
                        });
                }

                _context.SaveChanges();
            }

            //admin user

            List<string> users = new List<string>()
            {
                User.AdminUserName
            };
            for (int i = 1; i < 5; i++)
            {
                users.Add("user" + i);
            }

            foreach (var t in users)
            {
                var user = _context.Users.FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == t);
                if (user == null)
                {
                    user = User.CreateUser(_tenantId, t, t + "@defaulttenant.com", User.DefaultPassword);
                    user.IsEmailConfirmed = true;
                    user.IsActive = true;

                    _context.Users.Add(user);
                    _context.SaveChanges();

                    //Assign Admin role to admin user
                    _context.UserRoles.Add(new UserRole(_tenantId, user.Id, adminRole.Id));
                    _context.SaveChanges();
                }

            }
        }
    }
}