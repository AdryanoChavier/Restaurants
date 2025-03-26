using Restaurants.Application.DTOs;

namespace Restaurants.Application.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
        Task<RestaurantDto?> GetById(int id);
        Task<int> Create(CreateRestaurantDto dto);
    }
}
