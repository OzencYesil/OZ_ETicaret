using MediatR;
using OZ_ETicaret.Application.Repositories.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.ProductCommands.AddProductCommand
{
    public class AddProductCommandHandler(IProductWriteRepository productWriteRepository) : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            await productWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
                Category = request.Category
            });

            await productWriteRepository.SaveAsync();

            return new();
        }
    }
}
