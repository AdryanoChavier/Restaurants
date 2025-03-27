using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurantCommand;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
    IMapper mapper,
    IRestaurantRepository restaurantRepository) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating restaurant with id : {@restaurant} with {@id}  ",request, request.Id);
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
        if (restaurant is null)
            return false;

        mapper.Map(request, restaurant);

        await restaurantRepository.SaveChanges();

        return true;

    }
}
