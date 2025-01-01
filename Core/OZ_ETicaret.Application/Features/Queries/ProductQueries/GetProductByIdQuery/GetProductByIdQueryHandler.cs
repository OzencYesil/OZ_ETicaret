using MediatR;
using OZ_ETicaret.Application.Repositories.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Queries.ProductQueries.GetProductByIdQuery
{
    public class GetProductByIdQueryHandler(IProductReadRepository productReadRepository) : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await productReadRepository.GetByIdAsync(request.Id);
            return new() { Product = data};
        }
    }
}
