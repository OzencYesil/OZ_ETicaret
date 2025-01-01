using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Queries.CartItemQuery.GetActiveCartItemsCountQuery
{
    public class GetActiveCartItemsCountQueryRequest : IRequest<GetActiveCartItemsCountQueryResponse>
    {
        public string UserName { get; set; }
    }
}
