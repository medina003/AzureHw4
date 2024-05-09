using Microsoft.EntityFrameworkCore;
using TurboAzHw.Models;

namespace TurboAzHw.DbContexts
{
    public class CarContext : DbContext
    {
        public CarContext()
        {
        }

        public CarContext(DbContextOptions<CarContext> options)
        : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Description).IsRequired().HasMaxLength(200); ;
                entity.Property(p => p.Model).HasMaxLength(50); ;
                entity.Property(p => p.Price);
                entity.Property(p => p.Speed);
                entity.Property(p => p.Color);
                entity.Property(p => p.Image);
            });
        }
    }
}
