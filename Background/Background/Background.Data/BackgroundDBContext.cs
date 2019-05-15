using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Background.Data.Mappings;
using Background.Data.Migrations;
using Background.Entities;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserMap());
          
        }
    }
}
