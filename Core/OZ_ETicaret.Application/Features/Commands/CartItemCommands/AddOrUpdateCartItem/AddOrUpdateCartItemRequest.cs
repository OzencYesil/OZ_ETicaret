using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.CartItemCommands.AddOrUpdateCartItem
{
    public class AddOrUpdateCartItemRequest : IRequest<AddOrUpdateCartItemResponse>
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
