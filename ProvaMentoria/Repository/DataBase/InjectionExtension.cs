using MySql.Data.MySqlClient;

namespace Mentoria.Repository.DataBase
{
    public static class InjectExtension
    {
        public static IServiceCollection InjectData(this IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            var stringBase = configurationRoot.GetSection("databaseConfig");
            var dbhost = stringBase.GetSection("hostdb").Value;
            var dbuser = stringBase.GetSection("userdb").Value;
            var dbpassword = stringBase.GetSection("password").Value;
            var dbport = stringBase.GetSection("port").Value;
            var db = stringBase.GetSection("database").Value;

            string stringConection = $"server={dbhost};port={dbport};database={db};user={dbuser};password={dbpassword}";

            services.AddScoped(x => new MySqlConnection(stringConection));


            return services;
        }

    }
}