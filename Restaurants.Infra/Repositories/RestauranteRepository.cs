using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infra.Persistence;

namespace Restaurants.Infra.Repositories;
public class RestauranteRepository(RestaurantsDbContext dbContext) : IRestaurantRepository
{
    public async Task<int> Create(Restaurant entity)
    {
        dbContext.Restaurants.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await dbContext.Restaurants
            .Include(x => x.Dishs)
            .ToListAsync();
        return restaurants;
    }
    public async Task<Restaurant?> GetByIdAsync(int id)
    {
        var restaurant = await dbContext.Restaurants
            .Include(x => x.Dishs)
            .FirstOrDefaultAsync(x => x.Id == id);
        return restaurant;
    }
}
