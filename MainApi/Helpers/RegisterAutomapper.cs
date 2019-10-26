

using AutoMapper;
using Domain.Services.Mapper;
using MainApi.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MainApi.Helpers
{
    public class RegisterAutomapper
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainMapper());
                mc.AddProfile(new MainApiMap());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
        } 
    }
}
