using Microsoft.EntityFrameworkCore;
using WeatherRest.Models;

namespace WeatherRest.Data
{
    public class WeatherApiDbContext : DbContext
    {
        public WeatherApiDbContext(DbContextOptions<WeatherApiDbContext> options) : base(options)
        {

        }

        public DbSet<WeatherCorrectionInfo> WeatherCorrectionInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherCorrectionInfo>(entity =>
            {
                entity.ToTable("WeatherCorrectionInfo");
                entity.HasKey(e => e.Id);

            });
        }
    }
}