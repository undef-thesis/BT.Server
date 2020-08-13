using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BT.Application.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace BT.Api.Middlewares
{
    internal sealed class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAuthTokenService service)
        {
            var allow = context.GetEndpoint();

            if (allow?.Metadata?.GetMetadata<IAllowAnonymous>() is object)
            {

                await _next(context);
                return;
            }
            
            var hasToken = context.Request.Headers.TryGetValue("Authorization", out var token);

            if (!hasToken)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            token = token.Single().Split(' ').Last();
            var isValid = service.Validate(token);

            if (isValid)
            {
                await _next(context);
                return;
            }

            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}