using ControleCustos.Controllers;
using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;
using ControleCustos.Dominio.Interface;
using ControleCustos.Infraestrutura;
using ControleCustos.Models;
using ControleCustos.Tests;
using ControleCustos.Tests.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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

        [TestInitialize]
        public void SetUp()
        {
            HttpContext.Current = FakeHttpContext.FakeHttp();
            HttpContext.Current.Session["USUARIO_LOGADO_CHAVE"] = new UsuarioModel("cassio@cwi.com.br", Permissao.Gerente);
        }

        [TestMethod]
        public void VerificarNoMetodoCarregarListaDeServicosDoProjetoAModelNaoEhNull()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            Projeto projeto = new Projeto(1, "Máquinas da felicidade", new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente), "Coca-cola", "C#", new DateTime(2016, 9, 20), new DateTime(2016, 12, 20), 100000.00M, 10, SituacaoProjeto.EmAndamento);
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(projeto);
            var controleRecursoRepositorio = new Mock<IControleRecursoRepositorio>();
            controleRecursoRepositorio.Setup(c => c.ListarServico(projeto)).Returns(new List<ControleRecurso>() { new ControleRecurso(1, new Projeto(1, "Máquinas da felicidade", new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente), "Coca-cola", "C#", new DateTime(2016, 9, 20), new DateTime(2016, 12, 20), 100000.00M, 10, SituacaoProjeto.EmAndamento), new Servico(), new DateTime(), new DateTime())});
            ProjetoController projetoController = new ProjetoController(projetoRepositorio.Object, null, null, controleRecursoRepositorio.Object, null);
            // Act
            var result = projetoController.CarregarListaDeServicosDoProjeto(1);

            // Assert
            Assert.AreNotEqual(null, result.Model);
        }

        [TestMethod]
        public void NoMetodoCarregarListaDeServicosDoProjetoDeveTerViewNameIgualA_ListaDeRecursosProjeto()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            Projeto projeto = new Projeto(1, "Máquinas da felicidade", new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente), "Coca-cola", "C#", new DateTime(2016, 9, 20), new DateTime(2016, 12, 20), 100000.00M, 10, SituacaoProjeto.EmAndamento);
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(projeto);
            var controleRecursoRepositorio = new Mock<IControleRecursoRepositorio>();
            controleRecursoRepositorio.Setup(c => c.ListarServico(projeto)).Returns(new List<ControleRecurso>() { new ControleRecurso(1, new Projeto(1, "Máquinas da felicidade", new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente), "Coca-cola", "C#", new DateTime(2016, 9, 20), new DateTime(2016, 12, 20), 100000.00M, 10, SituacaoProjeto.EmAndamento), new Servico(), new DateTime(), new DateTime()) });
            ProjetoController projetoController = new ProjetoController(projetoRepositorio.Object, null, null, controleRecursoRepositorio.Object, null);
            // Act
            var result = projetoController.CarregarListaDeServicosDoProjeto(1);

            // Assert
            Assert.AreEqual("_ListaDeRecursosProjeto", result.ViewName);
        }

        [TestMethod]
        public void NoMetodoCarregarListaDeServicosDoProjetoDeveMandarUmaModelNullPoisUsuarioEstaAcessandoAreaInvalida()
        {
            // Arrange
            string email = "cassio@cwi.com.br";
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(new Projeto(1, "Máquinas da felicidade", new Usuario(1, "Cassio Farias Machado", "gabriel@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente), "Coca-cola", "C#", new DateTime(2016, 9, 20), new DateTime(2016, 12, 20), 100000.00M, 10, SituacaoProjeto.EmAndamento));
            ProjetoController projetoController = new ProjetoController(projetoRepositorio.Object, null, null, null, null);
            // Act
            var result = projetoController.CarregarListaDeServicosDoProjeto(1);

            // Assert
            Assert.AreEqual(null, result.Model);
        }

        [TestMethod]
        public void NoMetodoCarregarListaDeServicosDoProjetoDeveMandarUmaView_ListaDeRecursosProjetoMesmoOUsuarioAcessandoAreaInvalida()
        {
            // Arrange
            string email = "cassio@cwi.com.br";
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(new Projeto(1, "Máquinas da felicidade", new Usuario(1, "Cassio Farias Machado", "gabriel@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente), "Coca-cola", "C#", new DateTime(2016, 9, 20), new DateTime(2016, 12, 20), 100000.00M, 10, SituacaoProjeto.EmAndamento));
            ProjetoController projetoController = new ProjetoController(projetoRepositorio.Object, null, null, null, null);
            // Act
            var result = projetoController.CarregarListaDeServicosDoProjeto(1);

            // Assert
            Assert.AreEqual("_ListaDeRecursosProjeto", result.ViewName);
        }

        [TestMethod]
        public void ListaProjetosFiltradaComoGerenteEFiltroVazioDeveRetornarView_ListaProjetosFiltrada()
        {
            // Arrange
            Usuario usuario = new Usuario(1, "Cassio", "cassio@cwi.com.br", "123", Permissao.Gerente);
            var usuarioRepositorio = new Mock<IUsuarioRepositorio>();
            usuarioRepositorio.Setup(ur => ur.BuscarPorEmail("cassio@cwi.com.br")).Returns(usuario);
            var usuarioServico = new UsuarioServico(usuarioRepositorio.Object, null);
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            projetoRepositorio.Setup(p => p.ListarPorGerente(usuario,"")).Returns(new List<Projeto>() { new Projeto(1, "Máquinas da felicidade", new Usuario(1, "Cassio Farias Machado", "gabriel@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente), "Coca-cola", "C#", new DateTime(2016, 9, 20), new DateTime(2016, 12, 20), 100000.00M, 10, SituacaoProjeto.EmAndamento) });
            ProjetoController projetoController = new ProjetoController(projetoRepositorio.Object, usuarioServico, null, null, null);
            // Act
            var result = projetoController.ListaProjetosFiltrada();

            // Assert
            Assert.AreEqual("_ListaProjetosFiltrada", result.ViewName);
        }

        [TestMethod]
        public void ListaProjetosFiltradaComoGerenteEFiltroQueNãoContemplaraNenhumProjetoOuGerenteDeveRetornarUmaModelComCount0()
        {
            // Arrange
            Usuario usuario = new Usuario(1, "Cassio", "cassio@cwi.com.br", "123", Permissao.Gerente);
            var usuarioRepositorio = new Mock<IUsuarioRepositorio>();
            usuarioRepositorio.Setup(ur => ur.BuscarPorEmail("cassio@cwi.com.br")).Returns(usuario);
            var usuarioServico = new UsuarioServico(usuarioRepositorio.Object, null);
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            projetoRepositorio.Setup(p => p.ListarPorGerente(usuario, "cwi")).Returns(new List<Projeto>());
            ProjetoController projetoController = new ProjetoController(projetoRepositorio.Object, usuarioServico, null, null, null);
            // Act
            var result = projetoController.ListaProjetosFiltrada("cwi") as PartialViewResult;

            // Assert
            Assert.AreEqual(0,((ListaProjetosModel) result.ViewData.Model).Projetos.Count);
        }

        [TestMethod]
        public void ListaProjetosFiltradaComoGerenteEFiltroQueContemplaraUmProjeto()
        {
            // Arrange
            Usuario usuario = new Usuario(1, "Cassio", "cassio@cwi.com.br", "123", Permissao.Gerente);
            var usuarioRepositorio = new Mock<IUsuarioRepositorio>();
            usuarioRepositorio.Setup(ur => ur.BuscarPorEmail("cassio@cwi.com.br")).Returns(usuario);
            var usuarioServico = new UsuarioServico(usuarioRepositorio.Object, null);
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            projetoRepositorio.Setup(p => p.ListarPorGerente(usuario, "coca")).Returns(new List<Projeto>() { new Projeto(1, "Máquinas da felicidade", new Usuario(1, "Cassio Farias Machado", "gabriel@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente), "Coca-cola", "C#", new DateTime(2016, 9, 20), new DateTime(2016, 12, 20), 100000.00M, 10, SituacaoProjeto.EmAndamento) });
            ProjetoController projetoController = new ProjetoController(projetoRepositorio.Object, usuarioServico, null, null, null);
            // Act
            var result = projetoController.ListaProjetosFiltrada("coca") as PartialViewResult;

            // Assert
            Assert.AreEqual(1, ((ListaProjetosModel)result.ViewData.Model).Projetos.Count);
        }

        [TestMethod]
        public void ListaProjetosFiltradaComoAdministradorEFiltroQueNãoContemplaraNenhumProjetoOuGerenteDeveRetornarUmaModelComCount0()
        {
            // Arrange
            Usuario usuario = new Usuario(1, "Cassio", "cassio@cwi.com.br", "123", Permissao.Gerente);
            var usuarioRepositorio = new Mock<IUsuarioRepositorio>();
            usuarioRepositorio.Setup(ur => ur.BuscarPorEmail("cassio@cwi.com.br")).Returns(usuario);
            var usuarioServico = new UsuarioServico(usuarioRepositorio.Object, null);
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            projetoRepositorio.Setup(p => p.ListarPorGerente(usuario, "cwi")).Returns(new List<Projeto>());
            ProjetoController projetoController = new ProjetoController(projetoRepositorio.Object, usuarioServico, null, null, null);
            // Act
            var result = projetoController.ListaProjetosFiltrada("cwi") as PartialViewResult;

            // Assert
            Assert.AreEqual(0, ((ListaProjetosModel)result.ViewData.Model).Projetos.Count);
        }


    }
}
