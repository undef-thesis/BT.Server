using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BT.Application.Common;
using BT.Application.DTO;
using BT.Domain.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.GlobalData.Queries
{
    public class GetLookingCitiesQueryHandler : IRequestHandler<GetLookingCitiesQuery, IEnumerable<CityDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetLookingCitiesQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDto>> Handle(GetLookingCitiesQuery query, CancellationToken cancellationToken)
        {
            var cities = await _dataContext.Cities.ToListAsync();
            var matchedCities = new List<City>();

            Regex word = new Regex($"{query.LookingCity.ToLowerInvariant()}.*");

            foreach(var city in cities)
            {
                Match match = word.Match(city.Name.ToLowerInvariant());

                if(!String.IsNullOrEmpty(match.Value))
                {
                    matchedCities.Add(city);
                }
            }

            var mapped = _mapper.Map<IEnumerable<City>, IEnumerable<CityDto>>(matchedCities);
            return mapped;
        }
    }
}