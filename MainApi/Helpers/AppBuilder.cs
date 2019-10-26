using Microsoft.AspNetCore.Builder;
using Dependency.Injection;

namespace MainApi.Helpers
{
    public static class RegisterAppBuilder
    {
        public static void Register(IApplicationBuilder app)
        {
            AppModule.Register(app);
        }
    }
}
