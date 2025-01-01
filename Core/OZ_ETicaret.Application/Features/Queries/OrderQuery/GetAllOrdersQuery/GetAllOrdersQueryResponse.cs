using OZ_ETicaret.Application.DTOs;
using OZ_ETicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Queries.OrderQuery.GetAllOrdersQuery
{
    public class GetAllOrdersQueryResponse
    {
        public List<ReadOrderDTO> Orders { get; set; } = new List<ReadOrderDTO>();
    }
}
