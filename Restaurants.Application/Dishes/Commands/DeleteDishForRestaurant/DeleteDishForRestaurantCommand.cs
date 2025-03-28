using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteDishForRestaurant;

public class DeleteDishForRestaurantCommand(int restaurantId, int dishid) : IRequest
{
    public int RestaurantId { get; set; } = restaurantId;
    public int Dishid { get; set; } = dishid;
}
