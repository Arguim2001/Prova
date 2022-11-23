using Moq;
using ProvaMentoria.Model;
using ProvaMentoria.Repository.DataBase.Interface;
using ProvaMentoria.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UsuarioTest.UnitTest
{
    public class ServiceUsuarioTest
    {
        private ServiceUsuario _serviceUsuario;
        private readonly Mock<IUsuarioRepository> _usuarioRepository = new();

        public ServiceUsuarioTest() => _serviceUsuario = new ServiceUsuario(_usuarioRepository.Object);

        [Theory]
        [InlineData("Argu", 01, "Brazil", "01/09/2001","061.013.953-32")]


        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>TEST POST<<<<<<<<<<<<<<<<<<<<<<<<<<<\\

        public async Task Post_Usuario_Return_Bool(string nome, int id, string endereco, string nascimento, string cpf)
        {
            //Arrange
            Usuario usuario = new();
            usuario.Nome = nome;
            usuario.Id = id;
            usuario.Endereco = endereco;
            usuario.Cpf = cpf;
            usuario.Nascimento = nascimento;

            _usuarioRepository.Setup(x => x.PostUsuario(usuario)).ReturnsAsync(true);

            //Act

            var result = await _serviceUsuario.PostUsuario(usuario);

            //Assert

            Assert.True(result);


        }


        [Theory]
        [InlineData("Argu", 01, "Brazil", "01/09/2001", "061.013.953-32")]

        public async Task Post_Usuario_Return_Error(string nome, int id, string endereco, string nascimento, string cpf)
        {
            //Arrange
            Usuario usuario = new();
            usuario.Nome = nome;
            usuario.Id = id;
            usuario.Endereco = endereco;
            usuario.Cpf = cpf;
            usuario.Nascimento = nascimento;

            _usuarioRepository.Setup(x => x.PostUsuario(usuario)).ReturnsAsync(false);

            //Act

            var result = await _serviceUsuario.PostUsuario(usuario);

            //Assert

            Assert.False(result);


        }
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>TEST PUT<<<<<<<<<<<<<<<<<<<<<<<<<<<\\

        [Theory]
        [InlineData("Argu", 01, "Brazil", "01/09/2001", "061.013.953-32")]
        public async Task Put_Usuario_Return_Error(string nome, int id, string endereco, string nascimento, string cpf)
        {
            //Arrange
            Usuario usuario = new();
            usuario.Nome = nome;
            usuario.Id = id;
            usuario.Endereco = endereco;
            usuario.Nascimento = nascimento;
            usuario.Cpf = cpf;

            _usuarioRepository.Setup(x => x.PutUsuario(usuario)).ReturnsAsync(false);

            //Act

            var result = await _serviceUsuario.PutUsuario(usuario);

            //Assert

            Assert.False(result);


        }
        [Theory]
        [InlineData("Argu", 01, "Brazil", "01/09/2001", "061.013.953-32")]
        public async Task Put_Usuario_Return_Bool(string nome, int id, string endereco, string nascimento, string cpf)
        {
            //Arrange
            Usuario usuario = new();
            usuario.Nome = nome;
            usuario.Id = id;
            usuario.Endereco = endereco;
            usuario.Nascimento = nascimento;
            usuario.Cpf = cpf;

            _usuarioRepository.Setup(x => x.PutUsuario(usuario)).ReturnsAsync(true);

            //Act

            var result = await _serviceUsuario.PutUsuario(usuario);

            //Assert

            Assert.True(result);


        }
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> TEST DELETE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\\

        [Theory]
        [InlineData(01)]

        public async Task Delete_Pessoa_Return_True(int id)
        {

            //Arrange
            Usuario usuario = new();

            usuario.Id = id;



            _usuarioRepository.Setup(x => x.DeleteUsuario(id)).ReturnsAsync(true);

            //Act
            var result = await _serviceUsuario.DeleteUsuario(id);

            //Assert

            Assert.True(result);
        }

        [Theory]
        [InlineData(01)]

        public async Task Delete_Pessoa_Return_Error(int id)
        {

            //Arrange
            Usuario usuario = new();

            usuario.Id = id;



            _usuarioRepository.Setup(x => x.DeleteUsuario(id)).ReturnsAsync(false);

            //Act
            var result = await _serviceUsuario.DeleteUsuario(id);

            //Assert

            Assert.False(result);
        }




    }
}
