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
    public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.HasKey(l => l.LectureId);

            builder.Property(l => l.LectureName)
                .IsRequired();

            builder.Property(l => l.LectureStartTime)
                .IsRequired();
            builder.Property(l => l.LectureEndTime)
                .IsRequired();

            builder.Property(l => l.DayOfWeek)
                .IsRequired();

            builder.HasMany(l => l.Departments)
                .WithMany(d => d.Lectures)
                .UsingEntity<DepartmentLecture>(
                    j => j.HasOne(dl => dl.Department)
                          .WithMany()
                          .HasForeignKey(dl => dl.DepartmentCode),
                    j => j.HasOne(dl => dl.Lecture)
                          .WithMany()
                          .HasForeignKey(dl => dl.LectureId)
                );

            builder.HasMany(l => l.Students)
                .WithOne()
                .HasForeignKey(ls => ls.LectureId);
        }
    }
}
