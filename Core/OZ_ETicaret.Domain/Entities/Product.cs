using OZ_ETicaret.Domain.Entities.Common;
using OZ_ETicaret.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Domain.Entities
{
    public class Product : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public CategoryType Category { get; set; }
        public ICollection<ProductImageFile> ProductImageFiles { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
