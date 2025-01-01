using MediatR;
using Microsoft.EntityFrameworkCore;
using OZ_ETicaret.Application.Repositories.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Queries.ProductQueries.GetProductsByCategoryQuery
{
    public class GetProductsByCategoryQueryHandler(IProductReadRepository productReadRepository) : IRequestHandler<GetProductsByCategoryQueryRequest, GetProductsByCategoryQueryResponse>
    {
        public async Task<GetProductsByCategoryQueryResponse> Handle(GetProductsByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var datas = await productReadRepository.GetAll()
                .Where(p => p.Category == request.CategoryType)
                .Include(p => p.ProductImageFiles)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    p.Description,
                    images = p.ProductImageFiles
                }).ToListAsync();

            return new() { Products = datas };
        }
    }
}
