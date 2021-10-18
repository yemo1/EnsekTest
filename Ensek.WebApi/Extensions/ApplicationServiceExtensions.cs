using Ensek.Core.Interfaces;
using Ensek.Infrastructure.Data;
using Ensek.Infrastructure.Data.Concrete;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ensek.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<EnergyContext>(options => {
                options.UseSqlServer(config.GetConnectionString("EnergyConnection"));
            });

            services.AddScoped<IReadMeterRepository,ReadMeterRepository>();
            return services;
        }
    }
}