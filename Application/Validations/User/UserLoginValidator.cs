using Application.Requests.User.Queries;
using FluentValidation;

namespace Application.Validations.User
{
    public class UserLoginValidator : AbstractValidator<GetProfileQueryDto>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Email is required");


            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password is required");

            RuleFor(x => x.Password)
                .MinimumLength(2)
                .WithMessage("Password must be more than 2 characters.");
        }
    }
}
