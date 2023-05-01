using APP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APP.Data
{
    public interface IRestService
    {
        Task<List<UsuarioItem>> GetUsuariosAsync ();
        Task<int> InsertUsuarioAsync (UsuarioItem item);
        Task<int> UpdateUsuarioAsync (UsuarioItem item);
        Task<int> DeleteUsuarioAsync (UsuarioItem id);
    }
}
