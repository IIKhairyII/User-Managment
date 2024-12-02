using Application.Responses.User;
using FluentValidation;

namespace Application.Validations.User
{
    public class EditUserValidator : AbstractValidator<UserDto>
    {
        public EditUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Email is required");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Last Name is required");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage("First is required");

            RuleFor(x => x).Must(u => u.Password!.Equals(u.ConfirmPassword!))
                .WithMessage("Passwords don't match")
                 .When(u => u.Password != null && u.ConfirmPassword != null);
        }
    }
}
