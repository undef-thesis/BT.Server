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

            if(ex is UserNotFoundException)
                code = (int)HttpStatusCode.NotFound;

            response.StatusCode = code;

            await response.WriteAsync(JsonConvert.SerializeObject(new
            {
                error = new ErrorResponse(ex)
            }));
        }
    }
}