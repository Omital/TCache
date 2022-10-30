using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using TCache.EntityFramework;

namespace TCache.Migrator
{
    [DependsOn(typeof(TCacheDataModule))]
    public class TCacheMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<TCacheDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}