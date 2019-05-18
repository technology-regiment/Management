using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Background.Data.Mappings;
using Background.Data.Migrations;
using Background.Entities;
using Background.Entities.SystemSetting;

namespace Background.Data
{
    public class BackgroundDbContext : DbContext
    {
        public BackgroundDbContext()
            : base("name = BackgroundDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BackgroundDbContext, Configuration>(true));
        }

        public DbSet<User> UserContext { get; set; }
        public DbSet<SystemUser> SystemUserContext { get; set; }
        public DbSet<SystemRole> SystemRoleContext { get; set; }
        public DbSet<SystemFunction> SystemFunctionContext { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new SystemUserMap());
            modelBuilder.Configurations.Add(new SystemRoleMap());
            modelBuilder.Configurations.Add(new SystemFuntionMap());
        }
    }
}
