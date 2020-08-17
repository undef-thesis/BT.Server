using BT.Application.Features.AuthFeatures.Commands;
using BT.Application.Validators.Auth;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BT.Application.Validators
{
    public static class ConfigureValidators
    {
        public static void SetupValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<RegisterCommand>, RegisterValidator>();
            services.AddTransient<IValidator<LoginCommand>, LoginValidator>();
        }
    }
}