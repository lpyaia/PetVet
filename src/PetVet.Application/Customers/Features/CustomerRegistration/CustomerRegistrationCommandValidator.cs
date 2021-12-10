using FluentValidation;
using FluentValidation.Validators;

namespace PetVet.Application.Customers.Features.CustomerRegistration
{
    public class CustomerRegistrationCommandValidator : AbstractValidator<CustomerRegistrationCommand>
    {
        public CustomerRegistrationCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);

            RuleFor(x => x.FirstName)
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}