using BT.Application.Features.AuthFeatures.Commands.Login;
using BT.Application.Features.AuthFeatures.Commands.Register;
using BT.Application.Features.CommentFeatures.Commands.AddComment;
using BT.Application.Features.MeetingFeatures.Commands.AddMeeting;
using BT.Application.Features.MeetingFeatures.Commands.DeleteMeeting;
using BT.Application.Features.MeetingFeatures.Commands.JoinMeeting;
using BT.Application.Features.MeetingFeatures.Commands.UpdateMeeting;
using BT.Application.Features.UserProfileFeatures.Commands.ChangePassword;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BT.Application.Validators
{
    public static class ConfigureValidators
    {
        public static void SetupValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<RegisterCommand>, RegisterCommandValidator>();
            services.AddTransient<IValidator<LoginCommand>, LoginCommandValidator>();

            services.AddTransient<IValidator<AddMeetingCommand>, AddMeetingCommandValidator>();
            services.AddTransient<IValidator<JoinMeetingCommand>, JoinMeetingCommandValidator>();
            services.AddTransient<IValidator<DeleteMeetingCommand>, DeleteMeetingCommandValidator>();
            services.AddTransient<IValidator<UpdateMeetingCommand>, UpdateMeetingCommandValidator>();

            services.AddTransient<IValidator<AddCommentCommand>, AddCommentCommandValidator>();

            services.AddTransient<IValidator<ChangePasswordCommand>, ChangePasswordCommandValidator>();
        }
    }
}