using BT.Application.Features.AuthFeatures.Commands.Register;
using FluentValidation;

namespace BT.Application.Features.AuthFeatures.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(user => user.Email)
                .EmailAddress()
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