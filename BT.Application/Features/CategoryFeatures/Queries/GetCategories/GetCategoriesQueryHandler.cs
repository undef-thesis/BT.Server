using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BT.Application.Common;
using BT.Application.DTO;
using BT.Domain.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.CategoryFeatures.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
        {
            var categories = await _dataContext.Categories.ToListAsync();

            var mapped = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
            
            return mapped;  
        }
    }
}