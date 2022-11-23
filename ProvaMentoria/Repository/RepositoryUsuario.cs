using Dapper;
using Mentoria.Repository.DataBase;
using MySql.Data.MySqlClient;
using ProvaMentoria.Model;
using ProvaMentoria.Repository.DataBase.Interface;

public class RepositoryUsuario : BaseRepository, IUsuarioRepository
{

    public RepositoryUsuario(MySqlConnection mySqlConnection) : base(mySqlConnection)
    {

    }
    public async  Task <IEnumerable<Usuario>> GetUsuario( )
    {
        try
        {
            using (var connection = _sqlConnection)
            {
                string sql = $"SELECT * FROM usuario";
               var swl =  connection.Query(sql).ToList();
                //  var results = swl.ToList();

                return await swl;

            }
        }
        catch (Exception ex)
        {
            string erro = ex.Message;
            throw;
        }

    }
    public async Task<bool> PostUsuario (Usuario usuario)
    {
        string queryinsert = $"INSERT INTO usuario ( id, nome, cpf, nascimento, endereco ) VALUES ('{usuario.Id}','{usuario.Nome}','{usuario.Cpf}','{usuario.Nascimento}','{usuario.Endereco}')";
        return await MySql (queryinsert, null);
    }


    public async Task<bool> PutUsuario (Usuario usuario)
    {
        string queryupdate = $"UPDATE usuario SET nome = '{usuario.Nome}', cpf = '{usuario.Cpf}', nascimento = '{usuario.Nascimento}', endereco = '{usuario.Endereco}' WHERE id = {usuario.Id}";
        return await MySql(queryupdate, null);
    }

    public async Task<bool> DeleteUsuario(int id)
    {
        string querydelete = $"DELETE FROM usuario WHERE id = {id}";

        return await MySql(querydelete, null);
    }
}