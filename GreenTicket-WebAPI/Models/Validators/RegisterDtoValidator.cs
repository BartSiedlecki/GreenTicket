using FluentValidation;

namespace GreenTicket_WebAPI.Models.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(50)
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(50);

            RuleFor(x => x.RepeatPassword)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(50);

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.LastName)
               .NotEmpty()
               .MaximumLength(50);

            RuleFor(x => x.DateOfBirth)
                .NotNull();

            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.Street)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.StreetNo)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(x => x.CountryId)
                .NotEmpty();
        }   
    }
}
