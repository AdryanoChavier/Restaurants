using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurantQuery
{
    public class GetDishByIdForRestaurantQueryHandle(ILogger<GetDishByIdForRestaurantQuery> logger,
        IRestaurantRepository restaurantRepository,IMapper mapper) : IRequestHandler<GetDishByIdForRestaurantQuery, DishsDto>
    {
        public async Task<DishsDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving dish: {DishId}, for restaurant with id: {RestaurantId}", request.DishId,request.RestaurantId);
            var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);

            if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

           var dish = restaurant.Dishs.FirstOrDefault(d => d.Id == request.DishId);
           if(dish == null) throw new NotFoundException(nameof(Dish), request.DishId.ToString());

            var result = mapper.Map<DishsDto>(dish);

            return result;
        }
    }
}
