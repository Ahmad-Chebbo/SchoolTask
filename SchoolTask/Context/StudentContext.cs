using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolTask.Models;

namespace SchoolTask.Context
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map entities to tables 
            modelBuilder.Entity<Student>().ToTable("students");
        }
    }
}