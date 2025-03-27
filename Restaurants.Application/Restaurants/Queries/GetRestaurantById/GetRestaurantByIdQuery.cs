using MediatR;
using Restaurants.Application.DTOs;

namespace Restaurants.Application.Restaurants.Queries.GetById;

public class GetRestaurantByIdQuery(int id) : IRequest<RestaurantDto?>
{
    public int Id { get; set; } = id;
}
