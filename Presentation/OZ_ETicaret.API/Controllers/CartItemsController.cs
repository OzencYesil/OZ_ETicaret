using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OZ_ETicaret.Application.Features.Commands.CartItemCommands.AddOrUpdateCartItem;
using OZ_ETicaret.Application.Features.Commands.CartItemCommands.ChangeCartItemQuantityCommand;
using OZ_ETicaret.Application.Features.Commands.CartItemCommands.IncreaseOrDecreaseCartItemQuantityCommand;
using OZ_ETicaret.Application.Features.Queries.CartItemQuery.GetActiveCartItemQuery;
using OZ_ETicaret.Application.Features.Queries.CartItemQuery.GetActiveCartItemsCountQuery;

namespace OZ_ETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetActiveCartItems([FromQuery]GetActiveCartItemQueryRequest getActiveCartItemQueryRequest)
        {
            var response = await mediator.Send(getActiveCartItemQueryRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetActiveCartItemsCount([FromQuery] GetActiveCartItemsCountQueryRequest getActiveCartItemsCountQueryRequest)
        {
            var response = await mediator.Send(getActiveCartItemsCountQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCartItem(AddOrUpdateCartItemRequest addOrUpdateCartItemRequest)
        {
            await mediator.Send(addOrUpdateCartItemRequest);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ChangeCartItem(ChangeCartItemQuantityCommandRequest changeCartItemQuantityCommandRequest)
        {
            await mediator.Send(changeCartItemQuantityCommandRequest);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> IncreaseOrDecreaseCartItem(IncreaseOrDecreaseCartItemQuantityCommandRequest increaseOrDecreaseCartItemQuantityCommandRequest)
        {
            var response = await mediator.Send(increaseOrDecreaseCartItemQuantityCommandRequest);
            return Ok(response);
        }
    }
}
