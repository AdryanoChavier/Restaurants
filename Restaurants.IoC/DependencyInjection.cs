using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.DTOs.Validators;
using Restaurants.Application.Mappings;
using Restaurants.Application.Services;
using Restaurants.Domain.Repositories;
using Restaurants.Infra.Persistence;
using Restaurants.Infra.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.IoC;

public static class DependencyInjection 
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<RestaurantsDbContext>(
        options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(RestaurantsDbContext).Assembly.FullName)));

        #region Mapeamento
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        #endregion

        #region Validators
        services.AddValidatorsFromAssembly(typeof(CreateRestaurantDtoValidator).Assembly).AddFluentValidationAutoValidation();
        #endregion

        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();

        services.AddScoped<IRestaurantRepository, RestauranteRepository>();
        services.AddScoped<IRestaurantService, RestaurantsService>();

        
        return services;

    }
}
