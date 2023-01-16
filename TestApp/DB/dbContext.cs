using Microsoft.EntityFrameworkCore;

namespace TestApp
{
    
    public class dbContext : DbContext
    {
        private static bool _created = false;

        public dbContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=..\..\db1.db");

            SQLitePCL.Batteries.Init();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MousEvent>()
                .HasOne(p => p.user)
                .WithMany(b => b.mousEvents);
        }

        public DbSet<ServerUser> ServerUser { get; set; }

        public DbSet<MousEvent> MousEvent { get; set; }

    }
}
