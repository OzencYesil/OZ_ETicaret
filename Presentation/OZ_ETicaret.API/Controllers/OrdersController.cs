using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OZ_ETicaret.Application.Features.Commands.OrderCommands.OrderCreatedCommand;
using OZ_ETicaret.Application.Features.Queries.OrderQuery.GetAllOrdersQuery;

namespace OZ_ETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery]GetAllOrdersQueryRequest getAllOrdersQueryRequest)
        {
            GetAllOrdersQueryResponse response = await mediator.Send(getAllOrdersQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateNewOrder(OrderCreatedCommandRequest orderCreatedCommandRequest)
        {
            await mediator.Send(orderCreatedCommandRequest);
            return Ok();
        }
    }
}
