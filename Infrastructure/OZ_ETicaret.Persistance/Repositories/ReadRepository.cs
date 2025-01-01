using Microsoft.EntityFrameworkCore;
using OZ_ETicaret.Application.Repositories;
using OZ_ETicaret.Domain.Entities.Common;
using OZ_ETicaret.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Persistance.Repositories
{
    public class ReadRepository<T>(OzETicaretDbContext dbContext) : IReadRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table => dbContext.Set<T>();

        public IQueryable<T> GetAll(bool tracking = false)
        {
            var result = Table.AsQueryable();
            if (!tracking)
                result.AsNoTracking();
            return result;
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            var data = await Table.FirstOrDefaultAsync(m => m.Id.ToString() == id);
            return data;
        }
    }
}
