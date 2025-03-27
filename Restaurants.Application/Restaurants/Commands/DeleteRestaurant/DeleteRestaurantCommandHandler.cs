﻿using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
    IRestaurantRepository restaurantRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting restaurant with id : {@Id}", command.Id);
        var restaurant = await restaurantRepository.GetByIdAsync(command.Id);
        if (restaurant is null)
            return false;

        await restaurantRepository.Delete(restaurant);
        return true;
    }
}
