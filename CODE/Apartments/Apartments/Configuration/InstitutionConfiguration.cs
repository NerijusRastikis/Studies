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
    internal class InstitutionConfiguration : IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> builder)
        {
            builder.HasKey(a => a.InstitutionId);
            builder.Property(a => a.InstitutionId)
                .ValueGeneratedOnAdd();

            builder.HasOne(a => a.Owner)
                .WithOne(a => a.Institution);
            
        }
    }
}
