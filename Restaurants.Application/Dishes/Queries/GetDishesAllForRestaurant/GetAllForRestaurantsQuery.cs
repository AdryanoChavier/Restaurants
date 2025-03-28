using MediatR;
using Restaurants.Application.DTOs;

namespace Restaurants.Application.Dishes.Queries.GetAllForRestaurant;

public class GetAllForRestaurantsQuery(int restaurantId) : IRequest<IEnumerable<DishsDto>>
{
    public int RestaurantId { get; set; } = restaurantId;
}
