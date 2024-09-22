using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Database.Configuration
{
    public class LectureStudentConfiguration : IEntityTypeConfiguration<LectureStudent>
    {
        public void Configure(EntityTypeBuilder<LectureStudent> builder)
        {
            builder.HasKey(ls => new { ls.LectureId, ls.StudentNumber });

            builder.HasOne(ls => ls.Lecture)
                .WithMany(l => l.Students)
                .HasForeignKey(ls => ls.LectureId);

            builder.HasOne(ls => ls.Student)
                .WithMany(s => s.Lectures)
                .HasForeignKey(ls => ls.StudentNumber);
        }
    }

}
