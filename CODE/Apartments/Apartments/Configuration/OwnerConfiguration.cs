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
    internal class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasKey(a => a.OwnerId);
            builder.Property(a => a.Name)
                .IsRequired();
            builder.Property(a => a.Phone)
                .IsRequired();

            builder.HasOne(a => a.Institution)
                .WithOne(a => a.Owner);
        }
    }
}
