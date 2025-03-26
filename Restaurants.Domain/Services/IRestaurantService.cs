using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurants();
        Task<Restaurant?> GetById(int id);
    }
}
