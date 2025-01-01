using MediatR;
using Microsoft.AspNetCore.Identity;
using OZ_ETicaret.Application.Abstracts.Services;
using OZ_ETicaret.Application.DTOs;
using OZ_ETicaret.Application.Exceptions;
using OZ_ETicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.TokenCommands.CreateTokenCommand
{
    public class CreateTokenCommandHandler(ITokenService tokenService, UserManager<AppUser> userManager) : IRequestHandler<CreateTokenCommandRequest, CreateTokenCommandResponse>
    {
        async Task<CreateTokenCommandResponse> IRequestHandler<CreateTokenCommandRequest, CreateTokenCommandResponse>.Handle(CreateTokenCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser? user = await userManager.FindByNameAsync(request.UserName);
            

            if (user != null)
            {
                IList<string> roles = (await userManager.GetRolesAsync(user)).ToList();
                TokenDTO token = tokenService.CreateToken(request.Seconds, user, roles);
                return new() { Token = token.Token };
            }
            else
                throw new UserNotFoundException("Kullanıcı bulunamadı");

          
        }
    }
}
