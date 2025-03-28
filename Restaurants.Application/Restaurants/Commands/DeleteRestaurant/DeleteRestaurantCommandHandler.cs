using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
    IRestaurantRepository restaurantRepository) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting restaurant with id : {@Id}", command.Id);
        var restaurant = await restaurantRepository.GetByIdAsync(command.Id);
        if (restaurant is null)
            throw new NotFoundException(nameof(Restaurant), command.Id.ToString());
        await restaurantRepository.Delete(restaurant);
    }
}
