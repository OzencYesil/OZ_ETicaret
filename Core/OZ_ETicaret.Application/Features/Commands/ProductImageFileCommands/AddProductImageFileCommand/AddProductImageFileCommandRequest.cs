using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.ProductImageFileCommands.AddProductImageFileCommand
{
    public class AddProductImageFileCommandRequest : IRequest<AddProductImageFileCommandResponse>
    {
        public IFormFileCollection Files { get; set; }
        public string ProductId { get; set; }
    }
}
