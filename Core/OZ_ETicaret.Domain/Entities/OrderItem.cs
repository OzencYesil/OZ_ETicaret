using OZ_ETicaret.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public string ProductId { get; set; }
    }
}
