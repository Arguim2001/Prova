using ProvaMentoria.Service.Interface;

namespace ProvaMentoria.Service
{
    public static class InjectExtension
    {
        public static void InjectServices(this IServiceCollection service)
        {

            service.AddScoped<IServiceUsuario, ServiceUsuario>();
        }
    }
}
