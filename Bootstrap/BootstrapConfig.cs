using BLL.Interfaces;
using BLL.Services;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Business;

namespace Bootstrap
{
    public static class BootstrapConfig
    {
        public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddScoped<DbContext>(x => new ApplicationContextFactory()
                .CreateDbContext(new string[] { configuration.GetConnectionString("DefaultConnection") })); //TODO: change this parameter

            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient<IReadService<Credit>, CreditReadService>();
            services.AddTransient<IWriteService<Credit>, CreditWriteService>();
        }
    }
}
