﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Features.Queries.CartItemQuery.GetActiveCartItemsCountQuery
{
    public class GetActiveCartItemsCountQueryResponse 
    {
        public int ActiveCartItemCount { get; set; }
    }
}
