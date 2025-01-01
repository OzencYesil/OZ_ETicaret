using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Queries.UserQueries.GetUserIdQuery
{
    public class GetUserIdQueryRequest : IRequest<GetUserIdQueryResponse>
    {
        public string UserName { get; set; }
    }
}
