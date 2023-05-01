using WebAPI.Models;

namespace WebAPI.Data.Interfaces
{
    public interface IUserInterface
    {
        Task<IEnumerable<Usuario>> GetAllUsuarios();
        Task<Usuario> GetDetails(int id);
        Task<bool> InsertUsuario(Usuario usuario);
        Task<bool> UpdateUsuario(Usuario usuario);
        Task<bool> DeleteUsuario(Usuario usuario);
    }
}
