using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.UserCommands.UserLoginCommand
{
    public class UserLoginCommandRequest : IRequest<UserLoginCommandResponse>
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
    }
}
