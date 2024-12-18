using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Test.DAL.Entities;

namespace Test.DAL.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Logging> Loggings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure StudentCourse relationship
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => sc.Id); // Single-column primary key

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
