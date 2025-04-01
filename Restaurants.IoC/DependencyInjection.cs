using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Mappings;
using Restaurants.Domain.Entities;
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
        b => b.MigrationsAssembly(typeof(RestaurantsDbContext).Assembly.FullName)).EnableSensitiveDataLogging());

        #region Mapeamento
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        #endregion

        #region Validators
        services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.Load("Restaurants.Application")).AddFluentValidationAutoValidation();
        #endregion

        #region MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("Restaurants.Application")));
        #endregion

        #region Identity
        services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<RestaurantsDbContext>();
        #endregion

        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();

        services.AddScoped<IRestaurantRepository, RestauranteRepository>();

        services.AddScoped<IDishesRepository, DishesRepository>();

        return services;

    }
}
