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
    public class CartItemWriteRepository : WriteRepository<CartItem>, ICartItemWriteRepository
    {
        public CartItemWriteRepository(OzETicaretDbContext dbContext) : base(dbContext)
        {
        }
    }
}
