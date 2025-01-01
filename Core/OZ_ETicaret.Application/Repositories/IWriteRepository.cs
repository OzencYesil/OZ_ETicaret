using OZ_ETicaret.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T model);
        Task DeleteAsync(string id);
        Task SaveAsync();
        void Update(T model);
    }
}
