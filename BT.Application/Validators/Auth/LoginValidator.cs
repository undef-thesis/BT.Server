using BT.Application.Features.AuthFeatures.Commands;
using FluentValidation;

namespace BT.Application.Validators.Auth
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty();
            RuleFor(user => user.Password)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}