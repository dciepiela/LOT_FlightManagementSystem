using FlightManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementSystem.Persistence
{
    public class FlightsDbContext : DbContext
    {
        public FlightsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
    }
}
