using System.Collections.Generic;
using BT.Application.DTO;
using MediatR;

namespace BT.Application.Features.GlobalData.Queries
{
    public class GetLookingCitiesQuery : IRequest<IEnumerable<CityDto>>
    {
        public string LookingCity { get; set; }
    }
}