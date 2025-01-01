using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Domain.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpDate { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
