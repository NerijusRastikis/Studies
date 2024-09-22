using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Database.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentNumber);

            builder.Property(s => s.StudentNumber)
                .HasMaxLength(8)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(s => s.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.Email)
                .IsRequired();

            builder.HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentCode);

            builder.HasMany(s => s.Lectures)
                .WithOne()
                .HasForeignKey(ls => ls.StudentNumber);
        }
    }
}
