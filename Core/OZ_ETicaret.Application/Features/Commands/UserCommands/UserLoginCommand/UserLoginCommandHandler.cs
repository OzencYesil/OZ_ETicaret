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

namespace OZ_ETicaret.Application.Features.Commands.UserCommands.UserLoginCommand
{
    public class UserLoginCommandHandler(UserManager<AppUser> userManager, ITokenService tokenService) : IRequestHandler<UserLoginCommandRequest, UserLoginCommandResponse>
    {
        public async Task<UserLoginCommandResponse> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser? user = null;
            if(request.UserName != null)
                user = await userManager.FindByNameAsync(request.UserName);
            if (user == null && request.Email != null)
                user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new UserNotFoundException("Kullanıcı bulunamadı");
            else
            {
                bool result = await userManager.CheckPasswordAsync(user, request.Password);
                if (result)
                {
                    IList<string> roles = await userManager.GetRolesAsync(user);
                    TokenDTO token = tokenService.CreateToken(20, user, roles);
                    user.RefreshToken = token.RefreshToken;
                    user.RefreshTokenExpDate = token.ExpiringDate.AddSeconds(20);
                    await userManager.UpdateAsync(user);
                    UserLoginCommandResponse response = new() { Token = token.Token, RefreshToken= token.RefreshToken};
                    return response;
                }
                else
                    throw new Exception("Hatalı Giriş");
            }
        }
    }
}
