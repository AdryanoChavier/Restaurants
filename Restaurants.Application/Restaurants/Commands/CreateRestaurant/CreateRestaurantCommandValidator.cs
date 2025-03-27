using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> validCategories = ["Italian", "Mexican", "Japanese", "American", "Indian"];
    public CreateRestaurantCommandValidator()
    {
        RuleFor(x => x.Name).Length(3, 100);
        RuleFor(dto => dto.Category).Must(validCategories.Contains).WithMessage("Invalida Category. Please choose from the valid categoires.");
        RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("Please provide  a valid email address");
        RuleFor(dto => dto.PostalCode).Matches(@"^\d{2}-\d{3}$").WithMessage("Please provie a valid postalcode (XX-XXX)");
    }
}
