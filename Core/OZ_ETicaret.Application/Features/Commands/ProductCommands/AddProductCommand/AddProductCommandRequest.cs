using MediatR;
using OZ_ETicaret.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.ProductCommands.AddProductCommand
{
    public class AddProductCommandRequest : IRequest<AddProductCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public CategoryType Category { get; set; }
    }
}
