using Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Data
{
    public class Lab4DbContext(DbContextOptions<Lab4DbContext> options) : DbContext(options)
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
    }
}
