using FluentValidation;

namespace Restaurants.Application.DTOs.Validators;

public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    public CreateRestaurantDtoValidator()
    {
        RuleFor(x => x.Name).Length(3, 100);
        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(dto => dto.Category).NotEmpty().WithMessage("Insert a valid category");
        RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("Please provide  a valid email address");
        RuleFor(dto => dto.PostalCode).Matches(@"^\d{2}-\d{3}$").WithMessage("Description is required");
    }
}
