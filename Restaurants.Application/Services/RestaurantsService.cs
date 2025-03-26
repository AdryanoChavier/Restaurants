using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Services;

public class RestaurantsService(IRestaurantRepository restaurantRepository, ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantService
{
    public async Task<int> Create(CreateRestaurantDto dto)
    {
        logger.LogInformation("Creating a new restaurant");
        var restaurant = mapper.Map<Restaurant>(dto);
        int id = await restaurantRepository.Create(restaurant);
        return id;
    }

    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        return mapper.Map<IEnumerable<RestaurantDto>>(await restaurantRepository.GetAllAsync()); ;
    }

    public async Task<RestaurantDto?> GetById(int id)
    {
        logger.LogInformation($"Getting restaurant {id}");
        return mapper.Map<RestaurantDto>(await restaurantRepository.GetByIdAsync(id));
    }
}
