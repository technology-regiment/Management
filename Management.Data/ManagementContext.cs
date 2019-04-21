using Management.Data.Mappings;
using Management.Data.Migrations;
using Management.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data
{
    public class ManagementContext: DbContext
    {
        public ManagementContext():base("name=ManagementContext")
        {
            Database.SetInitializer <ManagementContext>(new MigrateDatabaseToLatestVersion<ManagementContext, Configuration>());
        }
        public DbSet<Book> BookContext { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new BookMap());
        } 
    }
}
