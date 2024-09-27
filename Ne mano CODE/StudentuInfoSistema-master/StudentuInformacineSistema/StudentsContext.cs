using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentuInformacineSistema.Database.Entities;

namespace StudentuInformacineSistema
{

    public class StudentsContext : DbContext
    {
        public StudentsContext() : base() { }
        public StudentsContext(DbContextOptions<StudentsContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentNumber);
                entity.Property(s => s.StudentNumber).ValueGeneratedNever();

                entity.HasOne(s => s.Department)
                      .WithMany(d => d.Students)
                      .HasForeignKey(s => s.DepartmentCode);

                entity.HasMany(s => s.Lectures)
                      .WithMany(l => l.Students)
                      .UsingEntity(j =>
                      {
                          j.ToTable("StudentLectures");
                          j.HasData(CSVDataService.GetStudentLectures());
                      });

                entity.HasData(CSVDataService.GetStudents());
                
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(d => d.DepartmentCode);

                entity.HasMany(d => d.Lectures)
                      .WithMany(l => l.Departments)
                      .UsingEntity(j =>
                      {
                          j.ToTable("DepartmentLectures");
                          j.HasData(CSVDataService.GetDepartmentLectures());
                      });

                entity.HasData(CSVDataService.GetDepartments());
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.HasKey(l => l.LectureName);
                entity.HasData(CSVDataService.GetLectures());
            });

        }
    }
}
