using Dapper;
using MySql.Data.MySqlClient;
using WebAPI.Models;

namespace WebAPI.Data.Interfaces
{
    public class UsuarioInterface : IUserInterface
    {
        private readonly MySqlConfiguration _configuration;
        public UsuarioInterface(MySqlConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_configuration.ConnectionString);
        }
        public async Task<bool> DeleteUsuario(Usuario usuario)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM usuarios WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = usuario.Id });
            return result > 0;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            var db = dbConnection();
            var sql = @" SELECT id, name, lastname, phone, email FROM usuarios";
            return await db.QueryAsync<Usuario>(sql, new {});
        }

        public async Task<Usuario> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT id, name, lastname, phone, email FROM usuarios WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }

        public async Task<bool> InsertUsuario(Usuario usuario)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO usuarios(name, lastname, phone, email)
                        VALUES(@Name, @Lastname, @Phone, @Email)";
            var result = await db.ExecuteAsync(sql, new 
            { usuario.Name, usuario.LastName, usuario.Phone, usuario.Email });

            return result > 0;
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            var db = dbConnection();
            var sql = @" UPDATE usuarios
                        SET name = @Name, lastname = @Lastname, phone = @Phone, email = @Email
                        WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new
            { usuario.Name, usuario.LastName, usuario.Phone, usuario.Email, usuario.Id });

            return result > 0;
        }
    }
}
