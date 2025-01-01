using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OZ_ETicaret.Application.Repositories;
using OZ_ETicaret.Domain.Entities.Common;
using OZ_ETicaret.Persistance.Contexts;

namespace OZ_ETicaret.Persistance.Repositories
{
    public class WriteRepository<T>(OzETicaretDbContext dbContext) : IWriteRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table => dbContext.Set<T>();

        public async Task AddAsync(T model)
        {
            await Table.AddAsync(model);
        }
        public async Task DeleteAsync(string id)
        {
            var model = await Table.FirstOrDefaultAsync(m => m.Id.ToString() == id);
            if(model != null)
                Table.Remove(model);
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Update(T model)
        {
            Table.Update(model);
        }
    }
}
