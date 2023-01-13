using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Data
{
    public class AplContext : DbContext
    {
        public AplContext()
        {
            Database.EnsureDeleted();   // удаляем бд со старой схемой
            Database.EnsureCreated();   // создаем бд с новой схемой
        }
        public AplContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Student> Students { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudCourses>(End =>
            {
                End.Property(sc => sc.Id).IsRequired();
                End.Property(sc => sc.Grades).IsRequired();
            });

            modelBuilder.Entity<Student>(End =>
            {
                End.Property(st => st.Id).IsRequired();
                End.Property(st => st.Fullname).HasMaxLength(40).IsRequired();
                End.Property(st => st.City).HasMaxLength(30).IsRequired();
                End.Property(st => st.Birthdate).HasColumnType("date");
            });


            modelBuilder.Entity<Courses>(End =>
            {
                End.HasKey(c => c.CoursesID);
                End.Property(t => t.Price).HasColumnType("money").IsRequired();
                End.Property(t => t.Description);
                End.HasMany(st => st.Students).WithMany(s => s.Courses).UsingEntity<StudCourses>(
                   j => j
                    .HasOne(pt => pt.Student)
                    .WithMany(t => t.StudCourses)
                    .HasForeignKey(pt => pt.Id),
                j => j
                    .HasOne(pt => pt.Courses)
                    .WithMany(p => p.StudCourses)
                    .HasForeignKey(pt => pt.CoursesID),
                j =>
                {
                    j.Property(pt => pt.EnrollmentDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.Property(pt => pt.Grades).HasDefaultValue(3);
                    j.HasKey(t => new { t.CoursesID, t.Id });
                    j.ToTable("StudCourses");
                });
            });

        }
    }
}

