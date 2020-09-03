using FluentValidation;

namespace BT.Application.Features.AuthFeatures.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty();
            RuleFor(user => user.Password)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}