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

namespace OZ_ETicaret.Application.Features.Queries.CartItemQuery.GetActiveCartItemQuery
{
    public class GetActiveCartItemQueryHandler(ICartItemReadRepository cartItemReadRepository, UserManager<AppUser> userManager) : IRequestHandler<GetActiveCartItemQueryRequest, GetActiveCartItemQueryResponse>
    {
        public async Task<GetActiveCartItemQueryResponse> Handle(GetActiveCartItemQueryRequest request, CancellationToken cancellationToken)
        {
            var cartItemList = await cartItemReadRepository.GetAll().Where(ci => ci.UserId == request.UserIdOrUserName && ci.Status == Domain.Enums.CartItemStatus.Active).Include(ci => ci.Product).ThenInclude(p => p.ProductImageFiles).Select(ci => new
            {
                CartItemId = ci.Id.ToString(),
                Name = ci.Product.Name,
                ProductId = ci.Product.Id.ToString(),
                Quantity = ci.Quantity,
                Price = ci.Product.Price,
                ProductImages = ci.Product.ProductImageFiles
            }).ToListAsync();

            if(!cartItemList.Any())
            {
                var user = await userManager.FindByNameAsync(request.UserIdOrUserName);

                cartItemList = await cartItemReadRepository.GetAll().Where(ci => ci.UserId == user.Id && ci.Status == Domain.Enums.CartItemStatus.Active).Include(ci => ci.Product).ThenInclude(p => p.ProductImageFiles).Select(ci => new
                {
                    CartItemId = ci.Id.ToString(),
                    Name = ci.Product.Name,
                    ProductId = ci.Product.Id.ToString(),
                    Quantity = ci.Quantity,
                    Price = ci.Product.Price,
                    ProductImages = ci.Product.ProductImageFiles
                }).ToListAsync();

                if (user == null)
                    throw new Exception("Kullanıcı bulunamadı");
            }

            return new() { CartItemList = cartItemList };
        }
    }
}
