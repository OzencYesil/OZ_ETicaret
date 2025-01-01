using MediatR;
using Microsoft.EntityFrameworkCore;
using OZ_ETicaret.Application.Repositories.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Queries.ProductQueries.GetAllProductQuery
{
    public class GetAllProductQueryHandler(IProductReadRepository productReadRepository) : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var datas = await productReadRepository.GetAll().
                Include(p => p.ProductImageFiles).Select(p =>new
            {
                p.Id,
                p.Name,
                p.Description,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate,
                Images = p.ProductImageFiles
            }).OrderBy(p => p.Name).ToListAsync();
            return new GetAllProductQueryResponse() { Products = datas };
        }
    }
}
