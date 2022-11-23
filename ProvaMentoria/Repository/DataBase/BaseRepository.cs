using Dapper;
using MySql.Data.MySqlClient;

namespace Mentoria.Repository.DataBase
{
    public abstract class BaseRepository
    {
        public readonly MySqlConnection _sqlConnection;

        protected BaseRepository(MySqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        protected async Task<bool> MySql(string sql, object parametros)
        {
            try
            {
                using (var connection = _sqlConnection)
                {
                    var linhas = await connection.ExecuteAsync(sql, parametros);
                    return linhas > 0;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}