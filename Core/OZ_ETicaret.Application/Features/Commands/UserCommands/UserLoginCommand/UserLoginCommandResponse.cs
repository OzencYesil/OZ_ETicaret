using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.UserCommands.UserLoginCommand
{
    public class UserLoginCommandResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
