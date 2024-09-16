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
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(a => a.ClientId);
            builder.Property(a => a.FullName)
                .IsRequired();
            builder.Property(a => a.PersonalCode)
                .IsRequired();
            builder.Property(a => a.Phone)
                .IsRequired();

            builder.HasMany(a => a.Apartments)
                .WithMany(a => a.Clients);
        }
    }
}
