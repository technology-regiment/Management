using Background.Entities.SystemSetting;
using System.Data.Entity.ModelConfiguration;

namespace Background.Data.Mappings
{
    public class SystemFuntionMap : EntityTypeConfiguration<SystemFunction>
    {
        public SystemFuntionMap()
        {
            //主键
            this.HasKey(t => t.Id);

            //属性
            this.Property(t => t.ParentId);
            this.Property(t => t.Name).IsRequired().HasMaxLength(128);
            this.Property(t => t.FunctionType).IsRequired();


            //表名和列配置
            this.ToTable("SystemFuntion");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
           
        }
    }
}
