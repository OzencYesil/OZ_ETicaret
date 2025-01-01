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

namespace OZ_ETicaret.Application.Features.Commands.TokenCommands.CreateRefreshTokenCommand
{
    public class CreateRefreshTokenCommandHandler(UserManager<AppUser> userManager, ITokenService tokenService) : IRequestHandler<CreateRefreshTokenCommandRequest, CreateRefreshTokenCommandResponse>
    {
        public async Task<CreateRefreshTokenCommandResponse> Handle(CreateRefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser? user = await userManager.FindByNameAsync(request.UserName);
            if (user != null && user.RefreshToken == request.RefreshToken && user.RefreshTokenExpDate>=DateTime.UtcNow)
            {
                IList<string> roles = await userManager.GetRolesAsync(user);
                TokenDTO token = tokenService.CreateToken(20, user, roles);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpDate = token.ExpiringDate.AddMinutes(10);
                await userManager.UpdateAsync(user);
                return new() { Token = token.Token, RefreshToken = token.RefreshToken };
            }
            else
                throw new Exception("İşlem başarırız");
        }
    }
}
