using MediatR;
using OZ_ETicaret.Application.Repositories.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.ProductCommands.DeleteProductCommand
{
    public class DeleteProductCommandHandler(IProductWriteRepository productWriteRepository) : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            await productWriteRepository.DeleteAsync(request.Id);
            await productWriteRepository.SaveAsync();
            return new();
        }
    }
}
