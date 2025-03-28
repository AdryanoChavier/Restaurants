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

    public async Task Delete(Dish entity)
    {
       dbContext.Dishs.Remove(entity);
       await dbContext.SaveChangesAsync();
    }

    public async Task DeleteRange(IEnumerable<Dish> entities)
    {
        dbContext.Dishs.RemoveRange(entities);
        await dbContext.SaveChangesAsync();
    }
}
