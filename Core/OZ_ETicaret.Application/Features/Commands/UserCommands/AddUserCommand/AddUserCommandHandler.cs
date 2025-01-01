using MediatR;
using Microsoft.AspNetCore.Identity;
using OZ_ETicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.UserCommands.AddUserCommand
{
    public class AddUserCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : IRequestHandler<AddUserCommandRequest, AddUserCommandResponse>
    {
        public async Task<AddUserCommandResponse> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult userResult = await userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                Email = request.Email
            }, request.Password);

            AddUserCommandResponse response = new();

            if (userResult.Succeeded)
                response.Message = "Kullanıcı başarıyla eklenmiştir";
            else
                foreach (var error in userResult.Errors)
                    response.Message += $"{error.Code} - {error.Description}";

            var user = await userManager.FindByNameAsync(request.UserName);
            IdentityResult roleResult = await userManager.AddToRoleAsync(user, "Customer");

            if(!roleResult.Succeeded)
                foreach (var error in userResult.Errors)
                    response.Message += $"{error.Code} - {error.Description}";

            return response;
        }
    }
}
