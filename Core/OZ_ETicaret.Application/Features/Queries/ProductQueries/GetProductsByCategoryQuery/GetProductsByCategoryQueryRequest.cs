using MediatR;
using OZ_ETicaret.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Queries.ProductQueries.GetProductsByCategoryQuery
{
    public class GetProductsByCategoryQueryRequest : IRequest<GetProductsByCategoryQueryResponse>
    {
        public CategoryType CategoryType { get; set; }
    }
}
