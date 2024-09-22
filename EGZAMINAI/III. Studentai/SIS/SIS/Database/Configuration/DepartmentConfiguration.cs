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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.DepartmentCode);

            builder.Property(d => d.DepartmentCode)
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(d => d.DepartmentName)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(d => d.Lectures)
                .WithMany(l => l.Departments)
                .UsingEntity<DepartmentLecture>(
                    j => j.HasOne(dl => dl.Lecture)
                          .WithMany()
                          .HasForeignKey(dl => dl.LectureId),
                    j => j.HasOne(dl => dl.Department)
                          .WithMany()
                          .HasForeignKey(dl => dl.DepartmentCode)
                );

            builder.HasMany(d => d.Students)
                .WithOne(s => s.Department)
                .HasForeignKey(s => s.DepartmentCode);
        }
    }
}
