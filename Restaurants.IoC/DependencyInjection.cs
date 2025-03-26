using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Services;
using Restaurants.Domain.Repositories;
using Restaurants.Domain.Services;
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

        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();

        services.AddScoped<IRestaurantRepository, RestauranteRepository>();
        services.AddScoped<IRestaurantService, RestaurantsService>();


        return services;

    }
}
