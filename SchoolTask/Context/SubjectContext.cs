using Microsoft.EntityFrameworkCore;
using SchoolTask.Models;

namespace SchoolTask.Context
{
    public class SubjectContext: DbContext
    {
        public SubjectContext(DbContextOptions<SubjectContext> options):base(options)
        { }

        public DbSet<Subject> Subjects { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {
            // Map entities to tables 
            modelBuilder.Entity<Subject>().ToTable("subjects");
        }  
    }
}