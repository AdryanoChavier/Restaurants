using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.DeleteDishesAllForRestaurant;
using Restaurants.Application.Dishes.Commands.DeleteDishForRestaurant;
using Restaurants.Application.Dishes.Queries.GetAllForRestaurant;
using Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurantQuery;
using Restaurants.Application.DTOs;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
namespace Restaurants.API.Controllers;

[Route("api/restaurants/{restaurantId}/dishes")]
[ApiController]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;

        await mediator.Send(command);
        return Created();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DishsDto>>> GetAllForRestaurant([FromRoute] int restaurantId)
    {
        var dishes = await mediator.Send(new GetAllForRestaurantsQuery(restaurantId));
        return Ok(dishes);
    }

    [HttpGet("{dishId}")]
    public async Task<ActionResult<DishsDto>> GetByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
    {
        var dishes = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId,dishId));
        return Ok(dishes);
    }

    [HttpDelete("{dishId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDishForRestaurant([FromRoute] int restaurantId, int dishId)
    {
        await mediator.Send(new DeleteDishForRestaurantCommand(restaurantId,dishId));

        return NoContent();

    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDishesAllForRestaurant([FromRoute] int restaurantId)
    {
        await mediator.Send(new DeleteDishesAllForRestaurantCommand(restaurantId));

        return NoContent();

    }

}

