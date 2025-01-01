using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Queries.CartItemQuery.GetActiveCartItemQuery
{
    public class GetActiveCartItemQueryRequest : IRequest<GetActiveCartItemQueryResponse>
    {
        public string UserIdOrUserName { get; set; }
    }
}
