using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infra.Persistence;

namespace Restaurants.Infra.Repositories;

public class DishesRepository(RestaurantsDbContext dbContext) : IDishesRepository
{
    public async Task<int> Create(Dish entity)
    {
        dbContext.Dishs.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }
}
