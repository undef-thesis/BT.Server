using MediatR;
using BT.Application.DTO;
using System.Threading.Tasks;
using System.Threading;
using BT.Application.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BT.Application.Features.UserProfileFeatures.Queries.GetUserProfile
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserPofileDto>
    {
        private readonly IDataContext _dataContext;

        public GetUserProfileQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<UserPofileDto> Handle(GetUserProfileQuery query, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Users.Include(x => x.Avatar).SingleOrDefaultAsync(x => x.Id == query.UserId);

            var userProfleDto = new UserPofileDto
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Avatar = user.Avatar.Picture
            };

            return userProfleDto;
        }
    }
}