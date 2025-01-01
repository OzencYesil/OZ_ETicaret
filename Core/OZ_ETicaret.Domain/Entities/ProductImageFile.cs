using OZ_ETicaret.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Domain.Entities
{
    public class ProductImageFile : FileEntity
    {
        public string Name { get; set; }
        public Product Product { get; set; }
    }
}
