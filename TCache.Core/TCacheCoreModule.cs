using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Zero;
using Abp.Zero.Configuration;
using System.Reflection;
using TCache.Authorization;
using TCache.Authorization.Roles;
using TCache.Authorization.Users;
using TCache.Configuration;
using TCache.MultiTenancy;

namespace TCache
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class TCacheCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;
            Configuration.Auditing.SaveReturnValues = true;

            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);


            //Remove the following line to disable multi-tenancy.
            Configuration.MultiTenancy.IsEnabled = TCacheConsts.MultiTenancyEnabled;

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    TCacheConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "TCache.Localization.Source"
                        )
                    )
                );

            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Authorization.Providers.Add<TCacheAuthorizationProvider>();

            Configuration.Settings.Providers.Add<AppSettingProvider>();

            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = TCacheConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
