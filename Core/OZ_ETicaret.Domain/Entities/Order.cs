using OZ_ETicaret.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Domain.Entities
{
    public class Order : BaseEntity
    {
        public AppUser AppUser { get; set; }
        public string Adress { get; set; }
        public string? Note { get; set; }
        public string ShippingInformations { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
