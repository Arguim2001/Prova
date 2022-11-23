using Microsoft.AspNetCore.Mvc;
using ProvaMentoria.Model;
using ProvaMentoria.Service.Interface;

namespace ProvaMentoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ControllerBase

    {
        private readonly IServiceUsuario _serviceUsuario;
        public UsuarioController(IServiceUsuario serviceUsuario)
        {
            _serviceUsuario = serviceUsuario;

        }

        [HttpGet ]
        public async Task<ActionResult> GetUsuario ()
        {

            return Ok( await _serviceUsuario.GetUsuario());
        }

        [HttpPost]
        public async Task<ActionResult> PostUsuario (Usuario usuario)
        {


            return Ok(await _serviceUsuario.PostUsuario(usuario));
        }

        [HttpPut]
        public async Task<ActionResult> PutUsuario(Usuario usuario)
        {


            return Ok(await _serviceUsuario.PutUsuario(usuario));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {


            return Ok(await _serviceUsuario.DeleteUsuario(id));
        }


    }
}
