using OZ_ETicaret.Application.DTOs;
using OZ_ETicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Abstracts.Services
{
    public  interface ITokenService
    {
        TokenDTO CreateToken(int seconds, AppUser user, IList<string> roles);
        string CreateRefreshToken();
    }
}
