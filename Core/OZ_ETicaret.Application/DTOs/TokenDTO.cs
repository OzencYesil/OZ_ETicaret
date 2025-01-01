using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.DTOs
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public DateTime ExpiringDate { get; set; }
        public string RefreshToken { get; set; }
    }
}
