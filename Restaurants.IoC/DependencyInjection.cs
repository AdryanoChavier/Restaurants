using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infra.Persistence;
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

        return services;

    }
}
