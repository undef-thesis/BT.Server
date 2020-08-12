using System;
using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Domain.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.AuthFeatures.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IDataContext _dataContext;

        public RegisterCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Email, request.Firstname, request.Lastname, request.Password, request.Password);

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            var newUser = await _dataContext.Users.SingleOrDefaultAsync(x => x.Id == user.Id);

            return Unit.Value;
        }
    }
}