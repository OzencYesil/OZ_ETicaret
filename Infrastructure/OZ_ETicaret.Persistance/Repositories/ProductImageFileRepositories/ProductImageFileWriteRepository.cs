using OZ_ETicaret.Application.Repositories.ProductImageRepositories;
using OZ_ETicaret.Domain.Entities;
using OZ_ETicaret.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Persistance.Repositories.ProductImageFileRepositories
{
    public class ProductImageFileWriteRepository : WriteRepository<ProductImageFile>, IProductImageFileWriteRepository
    {
        public ProductImageFileWriteRepository(OzETicaretDbContext dbContext) : base(dbContext)
        {
        }
    }
}
