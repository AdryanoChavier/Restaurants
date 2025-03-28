using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteDishesAllForRestaurant;

public class DeleteDishesAllForRestaurantCommandHandler(ILogger<DeleteDishesAllForRestaurantCommandHandler> logger, 
    IRestaurantRepository restaurantRepository,
    IDishesRepository dishesRepository) : IRequestHandler<DeleteDishesAllForRestaurantCommand>
{
    public async Task Handle(DeleteDishesAllForRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Removing all dishes  from restaurant: {RestaurantId}", request.RestaurantId);

        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        await dishesRepository.DeleteRange(restaurant.Dishs);
    }
}
