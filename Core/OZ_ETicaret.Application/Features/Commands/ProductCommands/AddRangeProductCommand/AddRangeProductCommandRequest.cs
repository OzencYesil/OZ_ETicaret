using MediatR;
using OZ_ETicaret.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.ProductCommands.AddRangeProductCommand
{
    public class AddRangeProductCommandRequest : IRequest<AddRangeProductCommandResponse>
    {
        public List<ProductDTO> Models { get; set; }
    }
}
