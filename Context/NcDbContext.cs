using Microsoft.EntityFrameworkCore;
using nc2.Models;

namespace nc2.Context
{
    public class NcDbContext : DbContext
    {
        public NcDbContext(DbContextOptions<NcDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataInitializer.Seed(modelBuilder);
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
   

        public DbSet<User> Users { get; set; }
      public DbSet<Cloud> Clouds { get; set; }
        public DbSet<UserNotebook> UserNotebooks { get; set; }
       
        public DbSet<UserCloud> UsersClouds { get; set; }
    }
}
