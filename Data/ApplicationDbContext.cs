using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            base.OnModelCreating(modelBuilder);
           modelBuilder.Entity<DiaryEntry>().HasData(new DiaryEntry
           {
               Id = 1,
               Title = "Welcome to your diary",
               Content = "This is your first diary entry.",
               Created = new DateTime(2025, 6, 30, 9, 0, 0)

           },
           new DiaryEntry
           {
               Id = 2,
               Title = "Welcome to your diary",
               Content = "This is your Second diary entry.",
               Created = new DateTime(2025, 6, 30, 9, 0, 0)

           }
           );
                
        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }
    }
}