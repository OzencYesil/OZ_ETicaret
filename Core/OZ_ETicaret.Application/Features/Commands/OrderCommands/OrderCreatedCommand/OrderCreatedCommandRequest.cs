using MediatR;
using OZ_ETicaret.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.OrderCommands.OrderCreatedCommand
{
    public class OrderCreatedCommandRequest : IRequest<OrderCreatedCommandResponse>
    {
        public string Adress { get; set; }
        public string? Note { get; set; }
        public string ShippingInformations { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
