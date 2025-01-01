using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.DTOs
{
    public class ReadOrderDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Adress { get; set; }
        public string ShippingInformations { get; set; }
        public string Note { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
