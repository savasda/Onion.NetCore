
using Infrastructure.Services.Context;
using Infrastucture.Interfaces.Interfaces;
using Microsoft.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Dependency.Injection
{
    public static class InfrastructuteModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            string defaultConnectionString = configuration.GetConnectionString("DefaultConnectionString");
            services.AddSingleton<IContextFactory, ContextFactory>();
            services.AddDbContext<DefaultContext>(options => options.UseSqlServer(defaultConnectionString));
        }
    }
}
