using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZ_ETicaret.Application.Features.Commands.RoleCommands.AddRoleCommand;
using OZ_ETicaret.Domain.Entities;

namespace OZ_ETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IMediator mediator, UserManager<AppUser> userManager) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddNewRole(AddRoleCommandRequest addRoleCommandRequest)
        {
            var result = await mediator.Send(addRoleCommandRequest);
            return Ok(result);
        }


    }
}
