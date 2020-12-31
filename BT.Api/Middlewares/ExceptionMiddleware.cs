using System;
using System.Net;
using System.Threading.Tasks;
using BT.Api.Filters;
using BT.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BT.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var code = (int)HttpStatusCode.InternalServerError;

            if (ex is UserNotFoundException)
                code = (int)HttpStatusCode.NotFound;
            else if (ex is TokenException)
                code = (int)HttpStatusCode.UnprocessableEntity;
            else if (ex is UserAlreadyExistsException)
                code = (int)HttpStatusCode.UnprocessableEntity;
            else if (ex is InvalidPasswordException)
                code = (int)HttpStatusCode.Forbidden;
            else if (ex is MeetingNotFoundException)
                code = (int)HttpStatusCode.NotFound;
            else if (ex is UserAlreadyBelongsToTheMeetingException)
                code = (int)HttpStatusCode.Conflict;
            else if (ex is MeetingHasNotFreeSlotsException)
                code = (int)HttpStatusCode.Conflict;

            response.StatusCode = code;

            await response.WriteAsync(JsonConvert.SerializeObject(new
            {
                error = new ErrorResponse(ex)
            }));
        }
    }
}