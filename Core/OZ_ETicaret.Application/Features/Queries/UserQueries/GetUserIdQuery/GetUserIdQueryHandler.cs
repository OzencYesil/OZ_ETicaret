using MediatR;
using Microsoft.AspNetCore.Identity;
using OZ_ETicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Queries.UserQueries.GetUserIdQuery
{
    public class GetUserIdQueryHandler(UserManager<AppUser> userManager) : IRequestHandler<GetUserIdQueryRequest, GetUserIdQueryResponse>
    {
        public async Task<GetUserIdQueryResponse> Handle(GetUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            if(user != null)
                return new() { UserId = user.Id };
            return new();
        }
    }
}
