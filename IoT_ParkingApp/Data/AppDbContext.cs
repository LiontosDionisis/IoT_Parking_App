using IoT_ParkingApp.Model;
using Microsoft.EntityFrameworkCore;

namespace IoT_ParkingApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        
        public DbSet<SensorData> SensorData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SensorData>()
                .HasIndex(s => s.DevEui).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
