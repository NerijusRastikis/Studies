using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManyToMany.Entities;

namespace ManyToMany.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("!Category!");
            builder.Property(b => b.Name)
                .HasColumnName("!Genre!");
            builder.Property(c => c.CategoryId)
                .HasColumnName("!CategoryID!");
        }
    }
}
