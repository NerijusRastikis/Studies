using ManyToMany.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("!Book!");
            builder.Property(b => b.Name)
                .HasColumnName("!Title!");
            builder.Property(c => c.Year)
                .HasColumnName("!Year!");
            builder.Property(d => d.BookId)
                .HasColumnName("!BookID!");
        }
    }
}
