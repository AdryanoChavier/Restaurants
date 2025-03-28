using MediatR;
using Restaurants.Application.DTOs;

namespace Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurantQuery;

public class GetDishByIdForRestaurantQuery(int restaurantId, int dishId) : IRequest<DishsDto>
{
    public int RestaurantId { get; set; } = restaurantId;
    public int DishId { get; set; } = dishId;

}
