using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteDishesAllForRestaurant
{
    public class DeleteDishesAllForRestaurantCommand(int restaurantId) : IRequest
    {
        public int RestaurantId { get; set; } = restaurantId;
    }
}
