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
    internal class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.HasKey(a => a.PlaceId);
            builder.Property(a => a.PlaceId)
                .IsRequired();
            builder.Property(a => a.Country)
                .IsRequired();
            builder.Property(a => a.City)
                .IsRequired();

            builder.HasMany(a => a.Institutions)
                .WithOne(a => a.Place);
        }
    }
}
