using Microsoft.EntityFrameworkCore;
using Restaurants.Infra.EntityConfig;

namespace Restaurants.Infra.Persistence;

public class RestaurantsDbContext : DbContext
{
    public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options): base(options)
    {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RestaurantConfig());
        modelBuilder.ApplyConfiguration(new DishConfig());
    }

}
