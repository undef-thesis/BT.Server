using BT.Application.Features.Behaviours;
using MediatR;

namespace BT.Application.Features.CategoryFeatures.Commands.AddCategory
{
    public class AddCategoryCommand : AuthRequest, IRequest
    {
        public string Name { get; set; }
    }
}