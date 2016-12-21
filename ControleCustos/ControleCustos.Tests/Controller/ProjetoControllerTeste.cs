using ControleCustos.Controllers;
using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;
using ControleCustos.Infraestrutura;
using ControleCustos.Models;
using ControleCustos.Tests.Controller;
using ControleCustos.Tests.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;

namespace ControleCustos.Tests
{
    [TestClass]
    public class ProjetoControllerTeste
    {
        private ProjetoController controller = new ProjetoController(
            new ProjetoRepositorioMock(), 
            new UsuarioServico(new UsuarioRepositorioMock(), new ServicoDeCriptografia()) ,
            new RecursoRepositorioMock(),
            new ControleRecursoRepositorioMock(),
            new CalculoServico(new ControleRecursoRepositorioMock()));
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            // Act
            var result = this.controller.CarregarModal(1,1);

            // Assert
            Assert.IsNotNull(result);
        }



        [TestInitialize]
        public void SetUp()
        {
            HttpContext.Current = FakeHttpContext.FakeHttp();
           HttpContext.Current.Session["USUARIO_LOGADO_CHAVE"] = new UsuarioModel("usuario@hotmail.com", Permissao.Gerente);
        }


    }
}
