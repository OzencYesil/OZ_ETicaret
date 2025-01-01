using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OZ_ETicaret.Application.Repositories.CartItemRepositories;
using OZ_ETicaret.Application.Repositories.CartRepositories;
using OZ_ETicaret.Application.Repositories.OrderRepositories;
using OZ_ETicaret.Application.Repositories.ProductImageRepositories;
using OZ_ETicaret.Application.Repositories.ProductRepositories;
using OZ_ETicaret.Persistance.Contexts;
using OZ_ETicaret.Persistance.Repositories.CartItemRepositories;
using OZ_ETicaret.Persistance.Repositories.CartRepositories;
using OZ_ETicaret.Persistance.Repositories.OrderRepositories;
using OZ_ETicaret.Persistance.Repositories.ProductImageFileRepositories;
using OZ_ETicaret.Persistance.Repositories.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<OzETicaretDbContext>(opt => opt.UseNpgsql(config.GetConnectionString("PostgreSQL")));

            

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductImageFileReadRepository,ProductImageFileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository,ProductImageFileWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<ICartItemReadRepository, CartItemReadRepository>();
            services.AddScoped<ICartItemWriteRepository, CartItemWriteRepository>();
            services.AddScoped<ICartReadRepository, CartReadRepository>();
            services.AddScoped<ICartWriteRepository, CartWriteRepository>();
        }
    }
}
