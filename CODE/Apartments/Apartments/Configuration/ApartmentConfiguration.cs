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
    internal class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasKey(a => a.ApartmentId);
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Type).IsRequired();
            builder.Property(a => a.RoomsCount).IsRequired();
            builder.Property(a => a.DailyPrice).IsRequired();

            builder.HasOne(a => a.Institution)
                .WithMany(a => a.Apartments);
        }
    }
}
