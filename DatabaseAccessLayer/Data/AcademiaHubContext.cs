using DatabaseAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Data
{
    public class AcademiaHubContext : DbContext
    {
        public AcademiaHubContext(DbContextOptions<AcademiaHubContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Hosteler> Hostelers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Section> Sections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Classes

            modelBuilder.Entity<Class>().HasData(
            new Class { ClassId = 1, ClassName = "Class 1" },
                new Class { ClassId = 2, ClassName = "Class 2" },
                new Class { ClassId = 3, ClassName = "Class 3" },
                new Class { ClassId = 4, ClassName = "Class 4" },
                new Class { ClassId = 5, ClassName = "Class 5" },
                new Class { ClassId = 6, ClassName = "Class 6" },
                new Class { ClassId = 7, ClassName = "Class 7" },
                new Class { ClassId = 8, ClassName = "Class 8" },
                new Class { ClassId = 9, ClassName = "Class 9" },
                new Class { ClassId = 10, ClassName = "Class 10" }
            );

            // Seed Sections

            modelBuilder.Entity<Section>().HasData(
           new Section { SectionId = 1, SectionName = "Section A" },
           new Section { SectionId = 2, SectionName = "Section B" },
           new Section { SectionId = 3, SectionName = "Section C" },
           new Section { SectionId = 4, SectionName = "Section D" },
           new Section { SectionId = 5, SectionName = "Section E" },
           new Section { SectionId = 6, SectionName = "Section F" },
           new Section { SectionId = 7, SectionName = "Section G" },
           new Section { SectionId = 8, SectionName = "Section H" },
           new Section { SectionId = 9, SectionName = "Section I" },
           new Section { SectionId = 10, SectionName = "Section J" }
            );

            // Seed Hostels
            modelBuilder.Entity<Hostel>().HasData(
                new Hostel { HostelId = 1, HostelName = "Hostel 1", HostelGender = "Male" },
                new Hostel { HostelId = 2, HostelName = "Hostel 2", HostelGender = "Female" },
                new Hostel { HostelId = 3, HostelName = "Hostel 3", HostelGender = "Male" },
                new Hostel { HostelId = 4, HostelName = "Hostel 4", HostelGender = "Female" },
                new Hostel { HostelId = 5, HostelName = "Hostel 5", HostelGender = "Male" },
                new Hostel { HostelId = 6, HostelName = "Hostel 6", HostelGender = "Female" },
                new Hostel { HostelId = 7, HostelName = "Hostel 7", HostelGender = "Male" },
                new Hostel { HostelId = 8, HostelName = "Hostel 8", HostelGender = "Female" },
                new Hostel { HostelId = 9, HostelName = "Hostel 9", HostelGender = "Male" },
                new Hostel { HostelId = 10, HostelName = "Hostel 10", HostelGender = "Female" }
            );

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Parent)
                .WithMany()
                .HasForeignKey(s => s.ParentId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Guardian)
                .WithMany()
                .HasForeignKey(s => s.GuardianId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Hosteler)
                .WithMany()
                .HasForeignKey(s => s.HostelerId);

            modelBuilder.Entity<Student>()
                .Property(s => s.EnrollmentNo)
                .ValueGeneratedNever();

            modelBuilder.Entity<Class>()
                .Property(c => c.ClassId)
                .ValueGeneratedNever();

            modelBuilder.Entity<Section>()
                .Property(s => s.SectionId)
                .ValueGeneratedNever();

            modelBuilder.Entity<Hostel>()
                .Property(h => h.HostelId)
                .ValueGeneratedNever();

            modelBuilder.Entity<Hosteler>()
                .Property(h => h.HostelerId)
                .ValueGeneratedNever();
        }
    }
}
