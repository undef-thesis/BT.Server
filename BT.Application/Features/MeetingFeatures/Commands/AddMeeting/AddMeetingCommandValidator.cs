using FluentValidation;

namespace BT.Application.Features.MeetingFeatures.Commands.AddMeeting
{
    public class AddMeetingCommandValidator : AbstractValidator<AddMeetingCommand>
    {
        public AddMeetingCommandValidator()
        {
            RuleFor(meeting => meeting.Name)
                .NotEmpty()
                .MaximumLength(150)
                .MinimumLength(3);
            RuleFor(meeting => meeting.Latitude)
                .NotEmpty();
            RuleFor(meeting => meeting.Longitude)
                .NotEmpty();        
        }
    }
}