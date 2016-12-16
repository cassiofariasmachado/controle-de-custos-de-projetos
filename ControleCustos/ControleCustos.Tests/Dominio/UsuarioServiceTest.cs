using ControleCustos.Dominio;
using ControleCustos.Dominio.Criptografia.Interface;
using ControleCustos.Dominio.UsuarioDominio.Classe;
using ControleCustos.Infraestrutura;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleCustos.Tests.Dominio
{
    [TestClass]
    public class UsuarioServiceTest
    {
        private IServicoDeCriptografia servicoDeCriptografia = new ServicoDeCriptografia();
        private UsuarioRepositorioMock usuarioMock = new UsuarioRepositorioMock();

        [TestMethod]
        public void TesteSenhaCertaEEmailCerto()
        {
            UsuarioServico usuarioServico = new UsuarioServico(usuarioMock, servicoDeCriptografia);

            Usuario retorno = usuarioServico.BuscarPorAutenticacao("usario@hotmail.com", "123");

            Assert.IsNotNull(retorno);
        }

        [TestMethod]
        public void TesteSenhaErradaEEmailCerto()
        {
            UsuarioServico usuarioServico = new UsuarioServico(usuarioMock, servicoDeCriptografia);

            Usuario retorno = usuarioServico.BuscarPorAutenticacao("usario@hotmail.com", "1233");

            Assert.IsNull(retorno);
        }

        [TestMethod]
        public void TesteSenhaCertaEEmailErrado()
        {
            UsuarioServico usuarioServico = new UsuarioServico(usuarioMock, servicoDeCriptografia);

            Usuario retorno = usuarioServico.BuscarPorAutenticacao("usario2@hotmail.com", "123");

            Assert.IsNull(retorno);
        }

        [TestMethod]
        public void TesteSenhaErradaEEmailErrado()
        {
            UsuarioServico usuarioServico = new UsuarioServico(usuarioMock, servicoDeCriptografia);

            Usuario retorno = usuarioServico.BuscarPorAutenticacao("usario@hotmail.com", "1233");

            Assert.IsNull(retorno);
        }
    }
}
