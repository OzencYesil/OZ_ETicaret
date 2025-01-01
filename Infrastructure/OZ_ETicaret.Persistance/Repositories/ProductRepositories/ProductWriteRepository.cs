using OZ_ETicaret.Application.Repositories.ProductRepositories;
using OZ_ETicaret.Domain.Entities;
using OZ_ETicaret.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Persistance.Repositories.ProductRepositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(OzETicaretDbContext dbContext) : base(dbContext)
        {
        }
    }
}
