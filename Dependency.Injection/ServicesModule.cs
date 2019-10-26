using Domain.Interfaces;
using Domain.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace Dependency.Injection
{
    public class ServicesModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IDeviceService, DeviceService>();
            services.AddSingleton<IUserService, UserService>();
        }
    }
}
