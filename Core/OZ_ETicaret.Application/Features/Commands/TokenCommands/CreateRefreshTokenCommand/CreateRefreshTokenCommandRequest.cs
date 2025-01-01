using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.TokenCommands.CreateRefreshTokenCommand
{
    public class CreateRefreshTokenCommandRequest : IRequest<CreateRefreshTokenCommandResponse>
    {
        public string UserName { get; set; }
        public string RefreshToken { get; set; }
    }
}
