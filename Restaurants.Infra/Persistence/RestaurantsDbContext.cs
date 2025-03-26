using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Infra.EntityConfig;

namespace Restaurants.Infra.Persistence;

public class RestaurantsDbContext : DbContext
{
    public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options): base(options)
    {}
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Dish> Dishes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RestaurantConfig());
        modelBuilder.ApplyConfiguration(new DishConfig());
    }

}
