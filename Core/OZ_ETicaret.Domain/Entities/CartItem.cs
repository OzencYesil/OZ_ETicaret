using OZ_ETicaret.Domain.Entities.Common;
using OZ_ETicaret.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public string UserId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Cart Cart { get; set; }
        public CartItemStatus Status { get; set; }
    }
}
