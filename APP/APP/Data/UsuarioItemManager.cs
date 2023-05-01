using APP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APP.Data
{
    public class UsuarioItemManager
    {
        IRestService restService;

        public UsuarioItemManager(IRestService service)
        {
            restService = service;
        }

        public async Task<List<UsuarioItem>> GetUsersAsync()
        {
            return await restService.GetUsuariosAsync();
        }

        public async Task<int> InsertUserAsync(UsuarioItem item)
        {
            return await restService.InsertUsuarioAsync(item);
        }

        public async Task<int> UpdateUserAsync(UsuarioItem item)
        {
            return await restService.UpdateUsuarioAsync(item);
        }

        public async Task<int> DeleteUserAsync(UsuarioItem item)
        {
            return await restService.DeleteUsuarioAsync(item);
        }
    }
}
