using System.Data.Entity.ModelConfiguration;
using Background.Entities;

namespace Background.Data.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            //主键
            this.HasKey(t => t.Id);

            //属性
            this.Property(t => t.Name).IsRequired().HasMaxLength(128);

            //表名和列配置
            this.ToTable("User");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
