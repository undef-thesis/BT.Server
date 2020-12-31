using BT.Application.Features.UserProfileFeatures.Commands.ChangePassword;
using FluentValidation;

namespace BT.Application.Features.MeetingFeatures.Commands.UpdateMeeting
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(password => password.Password)
                .NotEmpty()
                .MinimumLength(6);
            RuleFor(password => password.NewPassword)
                .NotEmpty()
                .MinimumLength(6);
            RuleFor(password => password.ConfirmNewPassword)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}