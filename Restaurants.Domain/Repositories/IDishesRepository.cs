﻿using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IDishesRepository
{
    Task<int> Create(Dish entity);
    Task Delete(Dish entity);
    Task DeleteRange(IEnumerable<Dish> entities);
}
