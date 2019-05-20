using Background.Entities.SystemSetting;
using System.Data.Entity.ModelConfiguration;

namespace Background.Data.Mappings
{
    public class SystemRoleMap : EntityTypeConfiguration<SystemRole>
    {
        public SystemRoleMap()
        {
            //主键
            this.HasKey(t => t.Id);

            //属性
            this.Property(t => t.Name).IsRequired().HasMaxLength(128);
            this.Property(t => t.Description).HasMaxLength(200);
            this.Property(t => t.CreateTime).IsRequired();

            //表名和列配置
            this.ToTable("SystemRole");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.LastModifiedTime).HasColumnName("LastModifyTime");

            // Relationships
            this.HasMany(x => x.SystemFunctions).WithMany(x => x.SystemRoles).
           Map(m => m.ToTable("SystemFunctionSystemRole").
               MapLeftKey("SystemFunctionId").
               MapRightKey("SystemRoleId"));
        }
    }
}
