using OZ_ETicaret.Application.Repositories.CartItemRepositories;
using OZ_ETicaret.Domain.Entities;
using OZ_ETicaret.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Persistance.Repositories.CartItemRepositories
{
    public class CartItemReadRepository : ReadRepository<CartItem>, ICartItemReadRepository
    {
        public CartItemReadRepository(OzETicaretDbContext dbContext) : base(dbContext)
        {
        }
    }
}
