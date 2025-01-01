using Microsoft.Extensions.DependencyInjection;
using OZ_ETicaret.Application.Abstracts.Services;
using OZ_ETicaret.Infrastructure.Concretes.Services;

namespace OZ_ETicaret.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
