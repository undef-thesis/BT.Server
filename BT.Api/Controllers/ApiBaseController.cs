using System;
using System.Threading.Tasks;
using BT.Application.Features.Behaviours;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BT.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiBaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
            Guid.Parse(User.Identity.Name) :
            Guid.Empty;

        public async Task<object> Execute<T>(T request)
        {
            if (request is AuthRequest authCommand)
            {
                authCommand.UserId = UserId;
            }

            return await Mediator.Send(request);
        }
    }
}