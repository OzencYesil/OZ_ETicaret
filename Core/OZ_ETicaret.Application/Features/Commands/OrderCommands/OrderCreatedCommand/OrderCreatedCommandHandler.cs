using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OZ_ETicaret.Application.Repositories.CartItemRepositories;
using OZ_ETicaret.Application.Repositories.CartRepositories;
using OZ_ETicaret.Application.Repositories.OrderRepositories;
using OZ_ETicaret.Application.Repositories.ProductRepositories;
using OZ_ETicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Commands.OrderCommands.OrderCreatedCommand
{
    public class OrderCreatedCommandHandler(IOrderWriteRepository orderWriteRepository, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IProductReadRepository productReadRepository, ICartWriteRepository cartWriteRepository, ICartReadRepository cartReadRepository, ICartItemWriteRepository cartItemWriteRepository, ICartItemReadRepository cartItemReadRepository) : IRequestHandler<OrderCreatedCommandRequest, OrderCreatedCommandResponse>
    {
        public async Task<OrderCreatedCommandResponse> Handle(OrderCreatedCommandRequest request, CancellationToken cancellationToken)
        {
            string? userName = httpContextAccessor.HttpContext.User?.Identity?.Name;
            if (userName == null)
            {
                string newUserName = $"Guest{Guid.NewGuid().ToString()}";
                await userManager.CreateAsync(new()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = newUserName,
                    Email = $"{newUserName}@nomail.com"
                }, $"{newUserName}123456");

                userName = newUserName;
            }


            AppUser appUser = await userManager.FindByNameAsync(userName);

            var order = new Order() 
            {
                AppUser = appUser,
                Adress = request.Adress,
                Note = request.Note,
                ShippingInformations = request.ShippingInformations,
                OrderItems = request.OrderItems.Select(oi => new OrderItem()
                {
                    ProductId = oi.ProductId,
                    Price = oi.Price,
                    Quantity = oi.Quantity
                }).ToList(),
                TotalPrice = request.OrderItems.Sum(oi => oi.Price * oi.Quantity)

            };


            await orderWriteRepository.AddAsync(order);

            var cart = await cartReadRepository.GetAll(tracking: true).FirstOrDefaultAsync(c => c.AppUser == appUser && c.CartStatus == Domain.Enums.CartStatus.Active);
            var cartItems = await cartItemReadRepository.GetAll(tracking: true).Where(ci => ci.UserId == appUser.Id && ci.Status == Domain.Enums.CartItemStatus.Active).ToListAsync();

            if (cart != null && cartItems != null)
            {
                cart.CartStatus = Domain.Enums.CartStatus.Completed;
                cartItems.ForEach(ci => ci.Status = Domain.Enums.CartItemStatus.Ordered);
            }

            await orderWriteRepository.SaveAsync();

            return new();
        }
    }
}
