using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OZ_ETicaret.Application.Repositories.CartItemRepositories;
using OZ_ETicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Queries.CartItemQuery.GetActiveCartItemsCountQuery
{
    public class GetActiveCartItemsCountQueryHandler(UserManager<AppUser> userManager, ICartItemReadRepository cartItemReadRepository) : IRequestHandler<GetActiveCartItemsCountQueryRequest, GetActiveCartItemsCountQueryResponse>
    {
        public async Task<GetActiveCartItemsCountQueryResponse> Handle(GetActiveCartItemsCountQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                var cartItemList = await cartItemReadRepository.GetAll().Where(ci => ci.UserId == user.Id && ci.Status == Domain.Enums.CartItemStatus.Active).ToListAsync();

                int totalCount = 0;

                foreach (var item in cartItemList)
                    totalCount += item.Quantity;

                return new() { ActiveCartItemCount = totalCount };
            }
            throw new Exception("Kullanıcı bulunamadı");
        }
    }
}
