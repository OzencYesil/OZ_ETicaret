using MediatR;
using Microsoft.EntityFrameworkCore;
using OZ_ETicaret.Application.Repositories.CartItemRepositories;
using OZ_ETicaret.Application.Repositories.CartRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.CartItemCommands.IncreaseOrDecreaseCartItemQuantityCommand
{
    public class IncreaseOrDecreaseCartItemQuantityCommandHandler(ICartItemReadRepository cartItemReadRepository, ICartItemWriteRepository cartItemWriteRepository, ICartWriteRepository cartWriteRepository) : IRequestHandler<IncreaseOrDecreaseCartItemQuantityCommandRequest, IncreaseOrDecreaseCartItemQuantityCommandResponse>
    {
        public async Task<IncreaseOrDecreaseCartItemQuantityCommandResponse> Handle(IncreaseOrDecreaseCartItemQuantityCommandRequest request, CancellationToken cancellationToken)
        {
            var cartItem = await cartItemReadRepository.GetAll().Where(ci => ci.Id.ToString() == request.CartItemId).Include(ci => ci.Cart)
                .Include(ci => ci.Product).FirstOrDefaultAsync();
            if (cartItem != null)
            {
                if (request.IncreaseOrDecrease == Enums.CartItemIncreaseOrDecrease.increase)
                {
                    cartItem.Quantity += 1;
                    cartItem.Cart.TotalPrice += cartItem.Product.Price;
                }
                else if (request.IncreaseOrDecrease == Enums.CartItemIncreaseOrDecrease.decrease)
                {
                    cartItem.Quantity -= 1;
                    cartItem.Cart.TotalPrice -= cartItem.Product.Price;
                }
                else
                    throw new Exception("Hatalı talimat girişi");

                if (cartItem.Quantity == 0)
                    await cartItemWriteRepository.DeleteAsync(cartItem.Id.ToString());
                if (!cartItem.Cart.CartItems.Any())
                    await cartWriteRepository.DeleteAsync(cartItem.Cart.Id.ToString());
                await cartItemWriteRepository.SaveAsync();
                return new();
            }
            throw new Exception("Ürün bulunamadı");
        }
    }
}
