using BT.Application.Features.AuthFeatures.Commands;
using FluentValidation;

namespace BT.Application.Validators.Auth
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty();
            RuleFor(user => user.Password)
                .NotEmpty()
                .MinimumLength(6)
                .Equal(user => user.ConfirmPassword).WithMessage("Passwords do not match");
            RuleFor(user => user.Firstname)
                .NotEmpty();
            RuleFor(user => user.Lastname)
                .NotEmpty();
        }
    }
}