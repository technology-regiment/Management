using Management.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace Management.Data.Mappings
{
    public class BookMap: EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            this.HasKey(t=>t.Id);
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Class)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.Prince)
                .IsRequired();

            this.ToTable("Book");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Class).HasColumnName("Class");
            this.Property(t => t.Prince).HasColumnName("Prince");
        }
    }
}
