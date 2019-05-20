using Background.Entities.SystemSetting;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Background.Data.Mappings
{
    public class SystemUserMap : EntityTypeConfiguration<SystemUser>
    {
        public SystemUserMap()
        {
            //主键
            this.HasKey(t => t.Id);

            //属性
            
            this.Property(t => t.Name).IsRequired().HasMaxLength(100);
            this.Property(t => t.PasswordHash).IsRequired().HasMaxLength(100);

            //表名和列配置
            this.ToTable("SyetemUser");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.PasswordHash).HasColumnName("PasswordHash");
            this.Property(t => t.LastLoginDate).HasColumnName("LastLoginDate");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.LastModifiedTime).HasColumnName("LastModifyTime");
            this.Property(t => t.AuthenticationToken).HasColumnName("AuthenticationToken");
            this.Property(t => t.AuthenticationTokenValidTo).HasColumnName("AuthenticationTokenValidTo");

            // Relationships
            this.HasRequired(t => t.SystemRole).WithMany(t => t.SystemUsers).HasForeignKey(t => t.SystemRoleId);
        }
    }
}
