using System;
using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Domain.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.CategoryFeatures.Commands.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand>
    {
        private readonly IDataContext _dataContext;

        public AddCategoryCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(AddCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _dataContext.Categories.SingleOrDefaultAsync(x => x.Name == command.Name);

            if(category != null)
            {
                throw new Exception("Category is exists");
            }

            category = new Category(command.Name);

            await _dataContext.Categories.AddAsync(category);
            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}