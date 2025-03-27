using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurantCommand;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
    IMapper mapper,
    IRestaurantRepository restaurantRepository) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating restaurant with id : {@restaurant} with {@id}  ",request, request.Id);
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
        if (restaurant is null)
            throw new NotFoundException($"Restaurant with {request.Id} doesn't exist");

        mapper.Map(request, restaurant);

        await restaurantRepository.SaveChanges();
    }
}
