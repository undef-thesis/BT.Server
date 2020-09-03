using FluentValidation;

namespace BT.Application.Features.MeetingFeatures.Commands.DeleteMeeting
{
    public class DeleteMeetingCommandValidator : AbstractValidator<DeleteMeetingCommand>
    {
        public DeleteMeetingCommandValidator()
        {
            RuleFor(meeting => meeting.Id)
                .NotEmpty();
        }
    }
}