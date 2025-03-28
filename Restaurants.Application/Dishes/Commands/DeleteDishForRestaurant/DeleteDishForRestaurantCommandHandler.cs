using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteDishForRestaurant;
public class DeleteDishForRestaurantCommandHandler(ILogger<DeleteDishForRestaurantCommandHandler> logger,
    IRestaurantRepository restaurantRepository, IDishesRepository dishesRepository
    ) : IRequestHandler<DeleteDishForRestaurantCommand>
{
    public async Task Handle(DeleteDishForRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Removing dish {DisheId} from restaurant: {RestaurantId}", request.Dishid, request.RestaurantId);

        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var dish = restaurant.Dishs.FirstOrDefault(d => d.Id == request.Dishid);
        if (dish == null) throw new NotFoundException(nameof(Dish), request.Dishid.ToString());

        await  dishesRepository.Delete(dish);
    }
}
