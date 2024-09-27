using Microsoft.EntityFrameworkCore;
using SIS.Database.Configuration;
using SIS.Database.Entities;
using SIS.Database.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS
{
    public class SISContext : DbContext
    {

        public SISContext() : base() { }
        public SISContext(DbContextOptions<SISContext> options) : base(options) { }
        public DbSet<Student> Students {  get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SIS_Egzaminas;Trusted_Connection=True;")
                    .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasData(CSVHelper.GetDepartments());
            modelBuilder.Entity<Lecture>()
                .HasData(CSVHelper.GetLectures());
            modelBuilder.Entity<Student>()
                .HasData(CSVHelper.GetStudents());

            modelBuilder.Entity<DepartmentLecture>().HasData(CSVHelper.GetDepartmentLectures());

            modelBuilder.Entity<LectureStudent>().HasData(CSVHelper.GetStudentLectures());

            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new LectureConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new LectureStudentConfiguration());
        }
    }
}
