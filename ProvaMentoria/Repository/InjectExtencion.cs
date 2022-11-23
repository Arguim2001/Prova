using Mentoria.Repository.DataBase;
using ProvaMentoria.Repository.DataBase.Interface;

namespace ProvaMentoria.Repository
{


    public static class InjectExtention
    {
        public static void InjectRepository(this IServiceCollection service, IConfigurationRoot configurationRoot)
        {
            service.InjectData(configurationRoot);
            service.AddScoped<IUsuarioRepository, RepositoryUsuario>();
        }
    }
}


