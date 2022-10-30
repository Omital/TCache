namespace TCache.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updatetoAbp74 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AbpNotifications", "TargetNotifiers", c => c.String(maxLength: 1024));
            AlterColumn("dbo.AbpUserNotifications", "TargetNotifiers", c => c.String(maxLength: 1024));
        }

        public override void Down()
        {
            AlterColumn("dbo.AbpUserNotifications", "TargetNotifiers", c => c.String());
            AlterColumn("dbo.AbpNotifications", "TargetNotifiers", c => c.String());
        }
    }
}
