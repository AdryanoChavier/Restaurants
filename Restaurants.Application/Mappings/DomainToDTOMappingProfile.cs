using AutoMapper;
using Restaurants.Application.DTOs;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {

        CreateMap<CreateRestaurantDto, Restaurant>()
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
