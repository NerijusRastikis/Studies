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
    internal class FacilitiesConfiguration : IEntityTypeConfiguration<Facilities>
    {
        public void Configure(EntityTypeBuilder<Facilities> builder)
        {
            builder.HasKey(a => a.FacilitiesId);
            builder.Property(a => a.FacilitiesId)
                .IsRequired();
            builder.Property(a => a.Title)
                .IsRequired();

            builder.HasMany(a => a.Apartments)
                .WithMany(a => a.Facilities);
        }
    }
}
