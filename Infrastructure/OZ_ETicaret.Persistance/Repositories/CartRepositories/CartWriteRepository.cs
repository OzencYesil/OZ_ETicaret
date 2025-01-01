using OZ_ETicaret.Application.Repositories;
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
    public class CartWriteRepository : WriteRepository<Cart>, ICartWriteRepository
    {
        public CartWriteRepository(OzETicaretDbContext dbContext) : base(dbContext)
        {
        }
    }
}
