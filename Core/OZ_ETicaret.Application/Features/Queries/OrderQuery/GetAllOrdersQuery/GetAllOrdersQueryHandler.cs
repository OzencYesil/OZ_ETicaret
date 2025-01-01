using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OZ_ETicaret.Domain.Entities;
using Npgsql;
using OZ_ETicaret.Application.DTOs;

namespace OZ_ETicaret.Application.Features.Queries.OrderQuery.GetAllOrdersQuery
{
    public class GetAllOrdersQueryHandler(IConfiguration config) : IRequestHandler<GetAllOrdersQueryRequest, GetAllOrdersQueryResponse>
    {
        public async Task<GetAllOrdersQueryResponse> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var dbConnection = new NpgsqlConnection(config.GetConnectionString("PostgreSQL"));

            var orders = (await dbConnection.QueryAsync<ReadOrderDTO>("select o.\"Id\"::text ,o.\"Adress\",o.\"ShippingInformations\",o.\"Note\",o.\"TotalPrice\", anu.\"UserName\" from \"Orders\" o \r\njoin \"AspNetUsers\" anu on o.\"AppUserId\" = anu.\"Id\" ")).ToList();

            var response = new GetAllOrdersQueryResponse();

            foreach (var order in orders)
                response.Orders.Add(new()
                {
                    Id = order.Id,
                    Adress = order.Adress,
                    Note = order.Note,
                    ShippingInformations = order.ShippingInformations,
                    TotalPrice = order.TotalPrice,
                    UserName = order.UserName
                });

            return response;
           
        }
    }
}
