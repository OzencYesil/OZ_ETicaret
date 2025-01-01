using MediatR;
using Microsoft.EntityFrameworkCore;
using OZ_ETicaret.Application.Repositories.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.ProductCommands.UpdateProductCommand
{
    public class UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository) : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var model = await productReadRepository.GetByIdAsync(request.Id);
            if (model != null)
            {
                model.Name = request.Name;
                model.Description = request.Description;
                model.Price = request.Price;
                model.Stock = request.Stock;
                productWriteRepository.Update(model);

                await productWriteRepository.SaveAsync();
            }
            
            return new();
        }
    }
}
