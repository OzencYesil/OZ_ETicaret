using MediatR;
using OZ_ETicaret.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.CartItemCommands.IncreaseOrDecreaseCartItemQuantityCommand
{
    public class IncreaseOrDecreaseCartItemQuantityCommandRequest : IRequest<IncreaseOrDecreaseCartItemQuantityCommandResponse>
    {
        public string CartItemId { get; set; }
        public CartItemIncreaseOrDecrease  IncreaseOrDecrease { get; set; }
    }
}
