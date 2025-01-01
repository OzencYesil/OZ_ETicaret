using MediatR;
using Microsoft.AspNetCore.Identity;
using OZ_ETicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.RoleCommands.AddRoleCommand
{
    public class AddRoleCommandHandler(RoleManager<AppRole> roleManager) : IRequestHandler<AddRoleCommandRequest, AddRoleCommandResponse>
    {
        public async Task<AddRoleCommandResponse> Handle(AddRoleCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await roleManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.RoleName
            });

            AddRoleCommandResponse response = new ();

            if (result.Succeeded)
                response.Message = "Rol başarıyla eklendi";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}";

            return response;
        }
    }
}
