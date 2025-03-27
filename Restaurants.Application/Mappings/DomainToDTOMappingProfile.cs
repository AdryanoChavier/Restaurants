using AutoMapper;
using Restaurants.Application.DTOs;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurantCommand;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<UpdateRestaurantCommand, Restaurant>();

        CreateMap<CreateRestaurantCommand, Restaurant>()
            .ForMember(d => d.Address, opt => opt.MapFrom(
                src => new Address
                {
                    City = src.City,
                    PostalCode = src.PostalCode,
                    Street = src.Street
                }));

        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(d => d.City, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(d => d.PostalCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(d => d.Dishs, opt => opt.MapFrom(src => src.Dishs));

        CreateMap<Dish, DishsDto>();

    }
}
