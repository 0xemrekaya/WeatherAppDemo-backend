using Microsoft.EntityFrameworkCore;

namespace DemoApp.Entities
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {

        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
