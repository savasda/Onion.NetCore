using Dependency.Injection;
using Domain.Services.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainApi.Helpers
{
    public static class RegisterDependencyInjectionModules
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            InfrastructuteModule.Register(services, configuration);
            ServicesModule.Register(services);
        }
    }
}
