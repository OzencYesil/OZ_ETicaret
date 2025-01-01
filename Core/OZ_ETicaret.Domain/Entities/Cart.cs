using OZ_ETicaret.Domain.Entities.Common;
using OZ_ETicaret.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public AppUser AppUser { get; set; }
        public CartStatus CartStatus{ get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<CartItem> CartItems { get; set; }

    }
}
