using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.CartItemCommands.ChangeCartItemQuantityCommand
{
    public class ChangeCartItemQuantityCommandRequest : IRequest<ChangeCartItemQuantityCommandResponse>
    {
        public string CartItemId { get; set; }
        public int NewQuantity { get; set; }
    }
}
