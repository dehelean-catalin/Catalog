using Microsoft.EntityFrameworkCore;
using SINU.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SINU.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }
        public DbSet<Class> Classes { set; get; }
        public DbSet<Student> Students { set; get; }
        public DbSet<StudyYear> StudyYears { set; get; }
        public DbSet<SubjectClass> SubjectsClass { set; get; }
        public DbSet<SubjectProfesor> SubjectsProfesor { set; get; }
        public DbSet<Subject> Subjects { set; get; }
        public DbSet<GradeInfo> Grades { set; get; }
        public DbSet<User> Users { set; get; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>(entity =>
            //{
            // entity.HasIndex(e => e.Id).IsUnique();
            //});

            modelBuilder.Entity<User>();
            modelBuilder.Entity<Student>();
            modelBuilder.Entity<Class>();
            modelBuilder.Entity<StudyYear>();
            modelBuilder.Entity<SubjectClass>();
            modelBuilder.Entity<SubjectProfesor>();
            modelBuilder.Entity<GradeInfo>();
            modelBuilder.Entity<Subject>();

        }



    
    }
}
