using FluentValidation;

namespace BT.Application.Features.CommentFeatures.Commands.AddComment
{
    public class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentCommandValidator()
        {
            RuleFor(comment => comment.MeetingId)
                .NotEmpty();
            RuleFor(comment => comment.Content)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(5000);
        }
    }
}