using OZ_ETicaret.Application.Repositories.CartRepositories;
using OZ_ETicaret.Domain.Entities;
using OZ_ETicaret.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Persistance.Repositories.CartRepositories
{
    public class CartReadRepository : ReadRepository<Cart>, ICartReadRepository
    {
        public CartReadRepository(OzETicaretDbContext dbContext) : base(dbContext)
        {
        }
    }
}
