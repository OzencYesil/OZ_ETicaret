using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.TokenCommands.CreateTokenCommand
{
    
     public   class CreateTokenCommandRequest : IRequest<CreateTokenCommandResponse>
    {
        public int Seconds { get; set; }
        public string UserName { get; set; }
    }
}
