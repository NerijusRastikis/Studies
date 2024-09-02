using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestoranasPOS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<MenuRepository>
    {
        public void Configure(EntityTypeBuilder<MenuRepository> builder)
        {
            builder.ToTable(nameof(MenuRepository));
            builder.HasKey(e => e.ID);
            builder.Property(e => e.ID)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            builder.Property(e => e.Type)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
