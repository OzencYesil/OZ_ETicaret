using OZ_ETicaret.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Domain.Entities
{
    public class InvoiceFile : FileEntity
    {
        public string InvoiceCode { get; set; }
    }
}
