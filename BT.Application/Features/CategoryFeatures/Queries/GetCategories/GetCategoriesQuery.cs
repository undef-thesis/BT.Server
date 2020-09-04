using System.Collections.Generic;
using BT.Application.DTO;
using BT.Application.Features.Behaviours;
using MediatR;

namespace BT.Application.Features.CategoryFeatures.Queries.GetCategories
{
    public class GetCategoriesQuery : AuthRequest, IRequest<IEnumerable<CategoryDto>>
    {
        
    }
}