using MediatR;
using OZ_ETicaret.Application.Abstracts.Services;
using OZ_ETicaret.Application.DTOs;
using OZ_ETicaret.Application.Repositories.ProductImageRepositories;
using OZ_ETicaret.Application.Repositories.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.ProductImageFileCommands.AddProductImageFileCommand
{
    public class AddProductImageFileCommandHandler(IFileService fileService, IProductImageFileWriteRepository productImageFileWriteRepository, IProductReadRepository productReadRepository) : IRequestHandler<AddProductImageFileCommandRequest, AddProductImageFileCommandResponse>
    {
        public async Task<AddProductImageFileCommandResponse> Handle(AddProductImageFileCommandRequest request, CancellationToken cancellationToken)
        {
            Dictionary<string,string> results = await fileService.UploadFiles(request.Files);

            var product = await productReadRepository.GetByIdAsync(request.ProductId);
            foreach (var result in results)
            {

                await productImageFileWriteRepository.AddAsync(new()
                {
                    Name = result.Key,
                    Path = result.Value,
                    Product = product
                });

                await productImageFileWriteRepository.SaveAsync();
            }

            return new();

            
        }
    }
}
