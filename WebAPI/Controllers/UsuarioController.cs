using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUserInterface _userInterface;
        public UsuarioController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            return Ok(await _userInterface.GetAllUsuarios());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioDetails(int id)
        {
            return Ok(await _userInterface.GetDetails(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody]Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _userInterface.InsertUsuario(usuario);

            return Created("created", created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userInterface.UpdateUsuario(usuario);

            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _userInterface.DeleteUsuario(new Usuario { Id = id });

            return NoContent();
        }
    }
}
