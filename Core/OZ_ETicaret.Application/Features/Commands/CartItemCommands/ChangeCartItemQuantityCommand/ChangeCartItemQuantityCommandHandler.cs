using MediatR;
using Microsoft.EntityFrameworkCore;
using OZ_ETicaret.Application.Repositories.CartItemRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.CartItemCommands.ChangeCartItemQuantityCommand
{
    public class ChangeCartItemQuantityCommandHandler(ICartItemReadRepository cartItemReadRepository, ICartItemWriteRepository cartItemWriteRepository) : IRequestHandler<ChangeCartItemQuantityCommandRequest, ChangeCartItemQuantityCommandResponse>
    {
        public async Task<ChangeCartItemQuantityCommandResponse> Handle(ChangeCartItemQuantityCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.NewQuantity < 0)
                throw new Exception("Lütfen geçerli bir miktar giriniz");

            var cartItem = await cartItemReadRepository.GetAll(tracking: true).Include(ci => ci.Cart).Include(ci => ci.Product).FirstOrDefaultAsync(ci => ci.Id.ToString() == request.CartItemId);

            decimal totalPriceDecreaseAmount = (cartItem.Quantity-request.NewQuantity) * cartItem.Product.Price;

            cartItem.Quantity = request.NewQuantity;

            if (cartItem.Quantity == 0)
            {
                await cartItemWriteRepository.DeleteAsync(request.CartItemId);
                cartItem.Cart.CartItems.Remove(cartItem);
            }

            cartItem.Cart.TotalPrice -= totalPriceDecreaseAmount;
               

            await cartItemWriteRepository.SaveAsync();

            return new();
        }
    }
}
