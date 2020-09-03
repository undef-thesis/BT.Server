using FluentValidation;

namespace BT.Application.Features.MeetingFeatures.Commands.UpdateMeeting
{
    public class UpdateMeetingCommandValidator : AbstractValidator<UpdateMeetingCommand>
    {
        public UpdateMeetingCommandValidator()
        {
            RuleFor(meeting => meeting.Id)
                .NotEmpty();
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