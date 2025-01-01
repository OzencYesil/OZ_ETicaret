using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OZ_ETicaret.Application.Features.Commands.TokenCommands.CreateRefreshTokenCommand;
using OZ_ETicaret.Application.Features.Commands.UserCommands.AddUserCommand;
using OZ_ETicaret.Application.Features.Commands.UserCommands.UserLoginCommand;
using OZ_ETicaret.Application.Features.Queries.UserQueries.GetUserIdQuery;

namespace OZ_ETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserId([FromQuery]GetUserIdQueryRequest getUserIdQueryRequest)
        {
            var result = await mediator.Send(getUserIdQueryRequest);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(AddUserCommandRequest addUserCommandRequest)
        {
            var result = await mediator.Send(addUserCommandRequest);
            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UserLogin(UserLoginCommandRequest userLoginCommandRequest)
        {
            var response = await mediator.Send(userLoginCommandRequest);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginRefreshToken(CreateRefreshTokenCommandRequest createRefreshTokenCommandRequest)
        {
            var response = await mediator.Send(createRefreshTokenCommandRequest);
            return Ok(response);
        }

    }
}
