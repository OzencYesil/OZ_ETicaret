using MediatR;
using OZ_ETicaret.Application.Repositories.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.ProductCommands.AddRangeProductCommand
{
    public class AddRangeProductCommandHandler(IProductWriteRepository productWriteRepository) : IRequestHandler<AddRangeProductCommandRequest, AddRangeProductCommandResponse>
    {
        public async Task<AddRangeProductCommandResponse> Handle(AddRangeProductCommandRequest request, CancellationToken cancellationToken)
        {
            foreach (var model in request.Models)
                await productWriteRepository.AddAsync(new()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Stock = model.Stock,
                    Category = model.Category
                });
            await productWriteRepository.SaveAsync();

            return new();
        }
    }
}
