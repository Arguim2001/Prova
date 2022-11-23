using Microsoft.AspNetCore.Mvc;
using ProvaMentoria.Model;
using ProvaMentoria.Repository.DataBase.Interface;
using ProvaMentoria.Service.Interface;

namespace ProvaMentoria.Service
{
    public class ServiceUsuario : IServiceUsuario
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public ServiceUsuario (IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> GetUsuario ()
        {
         return  await _usuarioRepository.GetUsuario();
        }

        public async Task<bool> PostUsuario(Usuario usuario)
        {
            var validation = await _usuarioRepository.GetUsuario(usuario.Nome);
            if (validation != null)
                return false;
            return await _usuarioRepository.PostUsuario(usuario);
        }
        public async Task<bool> PutUsuario(Usuario usuario)
        {
            return await _usuarioRepository.PutUsuario(usuario);
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            return await _usuarioRepository.DeleteUsuario(id);
        }


    }
}
