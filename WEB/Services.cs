using WEB.Interface;
using WEB.Service;

namespace WEB
{
    public static class Services
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IContaService, ContaService>();
        }
    }
}
