using OZ_ETicaret.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T: BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = false);
        Task<T?> GetByIdAsync(string id);
    }
}
