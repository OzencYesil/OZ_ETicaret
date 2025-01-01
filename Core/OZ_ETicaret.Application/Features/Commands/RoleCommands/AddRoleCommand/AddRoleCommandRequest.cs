using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.RoleCommands.AddRoleCommand
{
    public class AddRoleCommandRequest : IRequest<AddRoleCommandResponse>
    {
        public string RoleName { get; set; }
    }
}
