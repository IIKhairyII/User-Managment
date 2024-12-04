using Application.DTOs.User;
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
                .WithMessage("First Name is required");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password is required")
                .When(u => u.IsRegsiter);

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .NotNull()
                .WithMessage("Confirm Password is required")
                 .When(u => u.IsRegsiter);

            RuleFor(x => x)
                .Must(u => string.IsNullOrEmpty(u.Password) && string.IsNullOrEmpty(u.ConfirmPassword) ||
               (!string.IsNullOrEmpty(u.Password) && !string.IsNullOrEmpty(u.ConfirmPassword)))
                .WithMessage("Both Password and Confirm Password must be provided, or both must be empty.")
                .WithName("Passwords")
                .When(u => !u.IsRegsiter);



            RuleFor(x => x).Must(u => u.Password.Equals(u.ConfirmPassword))
                .WithMessage("Passwords don't match")
                .WithName("MathcPasswords")
                 .When(u => u.Password != null && u.ConfirmPassword != null);



        }
    }
}
