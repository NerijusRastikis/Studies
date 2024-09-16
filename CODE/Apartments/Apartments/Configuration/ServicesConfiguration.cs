using Apartments.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments.Configuration
{
    internal class ServicesConfiguration : IEntityTypeConfiguration<Services>
    {
        public void Configure(EntityTypeBuilder<Services> builder)
        {
            builder.HasKey(a => a.ServicesId);
            builder.Property(a => a.ServicesId)
                .IsRequired();
            builder.Property(a => a.Title)
                .IsRequired();
            builder.Property(a => a.Price)
                .IsRequired();

            builder.HasMany(a => a.Apartments)
                .WithMany(a => a.Services);
        }
    }
}
