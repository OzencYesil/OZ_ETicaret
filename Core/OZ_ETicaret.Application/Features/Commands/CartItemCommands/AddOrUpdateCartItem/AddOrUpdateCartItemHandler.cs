using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OZ_ETicaret.Application.Repositories.CartItemRepositories;
using OZ_ETicaret.Application.Repositories.CartRepositories;
using OZ_ETicaret.Application.Repositories.ProductRepositories;
using OZ_ETicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.CartItemCommands.AddOrUpdateCartItem
{
    public class AddOrUpdateCartItemHandler(ICartItemReadRepository cartItemReadRepository, ICartItemWriteRepository cartItemWriteRepository, IProductReadRepository productReadRepository,ICartReadRepository cartReadRepository, ICartWriteRepository cartWriteRepository, UserManager<AppUser> userManager) : IRequestHandler<AddOrUpdateCartItemRequest, AddOrUpdateCartItemResponse>
    {
        public async Task<AddOrUpdateCartItemResponse> Handle(AddOrUpdateCartItemRequest request, CancellationToken cancellationToken)
        {
            var cartItem = await cartItemReadRepository.GetAll(tracking: true).Include(ci => ci.Cart).Include(ci => ci.Product).FirstOrDefaultAsync(ci =>ci.UserId == request.UserId && ci.Product.Id.ToString() == request.ProductId && ci.Status == Domain.Enums.CartItemStatus.Active);

            if (cartItem != null)
            {
                cartItem.Quantity += request.Quantity;

                var cart = await cartReadRepository.GetByIdAsync(cartItem.Cart.Id.ToString());
                cart.TotalPrice += cartItem.Product.Price;
            }
            else
            {
                var product = await productReadRepository.GetByIdAsync(request.ProductId);

                var cart = await cartReadRepository.GetAll(tracking: true).FirstOrDefaultAsync(c => c.CartStatus == Domain.Enums.CartStatus.Active);

                if (cart == null)
                {
                    cart = new()
                    {
                        AppUser = await userManager.FindByIdAsync(request.UserId),
                        CartStatus = Domain.Enums.CartStatus.Active,
                        TotalPrice = 0
                    };

                    await cartWriteRepository.AddAsync(cart);
                } 

                await cartItemWriteRepository.AddAsync(new()
                {
                    UserId = request.UserId,
                    Product = product,
                    Cart = cart,
                    Quantity = request.Quantity,
                    Status = Domain.Enums.CartItemStatus.Active,
                });

                cart.TotalPrice += product.Price * request.Quantity;
            }
            await cartItemWriteRepository.SaveAsync();

            return new();
        }
    }
}
