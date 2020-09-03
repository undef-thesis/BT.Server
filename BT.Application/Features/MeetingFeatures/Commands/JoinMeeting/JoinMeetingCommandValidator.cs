using FluentValidation;

namespace BT.Application.Features.MeetingFeatures.Commands.JoinMeeting
{
    public class JoinMeetingCommandValidator : AbstractValidator<JoinMeetingCommand>
    {
        public JoinMeetingCommandValidator()
        {
            RuleFor(meeting => meeting.Id)
                .NotEmpty();
        }
    }
}