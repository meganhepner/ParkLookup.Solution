using Microsoft.EntityFrameworkCore;

namespace ParkLookup.Models
{
    public class ParkLookupContext : DbContext
    {
        public ParkLookupContext(DbContextOptions<ParkLookupContext> options)
            : base(options)
        {
        }

        public DbSet<StatePark> StateParks { get; set; }
        public DbSet<NationalPark> NationalParks { get; set; }
    }
}