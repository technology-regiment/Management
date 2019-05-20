namespace Background.Data.Migrations
{
    using Background.Common;
    using Background.Entities.Enum;
    using Background.Entities.SystemSetting;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static Background.Common.GuidProvider;

    internal sealed class Configuration : DbMigrationsConfiguration<BackgroundDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BackgroundDbContext context)
        {
            var migrationCreateDate = new DateTime(2019, 4, 24);
            //Role

            var manager = SystemRole.Create("管理人员", "系统管理员", UserIdProvider.Admin,
                migrationCreateDate);
            manager.ForceId(RoleIdProvider.Manager);
            context.SystemRoleContext.AddOrUpdate(manager);

            //用户
            if (!context.SystemUserContext.Any(x => x.Email == "admin@account.com"))
            {
                var user = SystemUser.Create("Admin", "admin@account.com", "Password1", RoleIdProvider.Manager,
                    UserStatus.Enable, migrationCreateDate);
                user.ForceId(UserIdProvider.Admin);
                context.SystemUserContext.AddOrUpdate(user);
              
            }
        }
    }
}
