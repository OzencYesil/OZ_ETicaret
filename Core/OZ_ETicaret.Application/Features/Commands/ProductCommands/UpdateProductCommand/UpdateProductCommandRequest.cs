using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.ProductCommands.UpdateProductCommand
{
    public class UpdateProductCommandRequest: IRequest<UpdateProductCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
    }
}
