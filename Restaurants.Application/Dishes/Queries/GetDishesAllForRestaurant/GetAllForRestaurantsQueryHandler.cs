using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetAllForRestaurant;

public class GetAllForRestaurantsQueryHandler(ILogger<GetAllForRestaurantsQueryHandler> logger,
    IMapper mapper,
    IRestaurantRepository restaurantRepository) : IRequestHandler<GetAllForRestaurantsQuery, IEnumerable<DishsDto>>
{
    public async Task<IEnumerable<DishsDto>> Handle(GetAllForRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrievind dishes for restaurant with id: {RestaurantId}", request.RestaurantId);
        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);

        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var results = mapper.Map<IEnumerable<DishsDto>>(restaurant.Dishs);

        return results;
    }
}
