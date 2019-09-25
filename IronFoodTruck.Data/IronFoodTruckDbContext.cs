using IronFoodTruck.Core;
using Microsoft.EntityFrameworkCore;

namespace IronFoodTruck.Data
{
    public class IronFoodTruckDbContext: DbContext
    {
        public IronFoodTruckDbContext(DbContextOptions<IronFoodTruckDbContext> options)
            :base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
