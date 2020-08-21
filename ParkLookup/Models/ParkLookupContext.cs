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

        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<StatePark>()
            .HasData(
                new StatePark { StateParkId = 1, StateParkName = "Chugach", StateParkState = "Alaska", StateParkHighlight = "grizzly bears", StateParkCamping = true, StateParkHiking = true, StateParkFishing = true },
                new StatePark { StateParkId = 2, StateParkName = "Silver Falls", StateParkState = "Oregon", StateParkHighlight = "waterfalls", StateParkCamping = true, StateParkHiking = true, StateParkFishing = false },
                new StatePark { StateParkId = 3, StateParkName = "Harriman", StateParkState = "Idaho", StateParkHighlight = "geothermal", StateParkCamping = true, StateParkHiking = false, StateParkFishing = true},
                new StatePark { StateParkId = 4, StateParkName = "Fort Flagler", StateParkState = "Washington", StateParkHighlight = "military bunker", StateParkCamping = true, StateParkHiking = false, StateParkFishing = true},
                new StatePark { StateParkId = 5, StateParkName = "Smith Rock", StateParkState = "Oregon", StateParkHighlight = "climbing", StateParkCamping = true, StateParkHiking = true, StateParkFishing = false}
            );

         builder.Entity<NationalPark>()
            .HasData(
                new NationalPark { NationalParkId = 1, NationalParkName = "Denali", NationalParkState = "Alaska", NationalParkHighlight = "largest mountain in AK", NationalParkCamping = true, NationalParkHiking = true, NationalParkFishing = true },
                new NationalPark { NationalParkId = 2, NationalParkName = "Olympic", NationalParkState = "Washington", NationalParkHighlight = "lodges, big trees", NationalParkCamping = true, NationalParkHiking = true, NationalParkFishing = true },
                new NationalPark { NationalParkId = 3, NationalParkName = "Crater Lake", NationalParkState = "Oregon", NationalParkHighlight = "lake", NationalParkCamping = true, NationalParkHiking = false, NationalParkFishing = false},
                new NationalPark { NationalParkId = 4, NationalParkName = "Mt St Helens", NationalParkState = "Washington", NationalParkHighlight = "volcano", NationalParkCamping = true, NationalParkHiking = true, NationalParkFishing = false},
                new NationalPark { NationalParkId = 5, NationalParkName = "Yellowstone National Park", NationalParkState = "Idaho", NationalParkHighlight = "geothermal", NationalParkCamping = true, NationalParkHiking = true, NationalParkFishing = false}
            );
        }
    }
}