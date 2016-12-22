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

        [TestInitialize]
        public void SetUp()
        {
            HttpContext.Current = FakeHttpContext.FakeHttp();
            HttpContext.Current.Session["USUARIO_LOGADO_CHAVE"] = new UsuarioModel("cassio@cwi.com.br", Permissao.Gerente);
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var recursoRepositorio = new Mock<IRecursoRepositorio>();
            var controleDeRecursoRepositorio = new Mock<IControleRecursoRepositorio>();
            var usuarioCassio = new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var usuarioGabriel = new Usuario(1, "Gabriel", "gabriel@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var usuarioAdministrador = new Usuario(1, "Administrador", "administrador@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Administrador);


        }

        [TestMethod]
        public void CarregarListaDeServicosDoProjetoGerenteAcessandoProjetoDeOutroGerenteDeveRetornarModelNull()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var usuarioGabriel = new Usuario(1, "Gabriel", "gabriel@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(new Projeto(1, "Guarana", usuarioGabriel, "Vonpar", "Java", new DateTime(), new DateTime(), 1000, 2, SituacaoProjeto.Novo));
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, null, null);
            // Act
            var result = projetoController.CarregarListaDeServicosDoProjeto(1);

            // Assert
            Assert.AreEqual(null, result.Model);
        }

        [TestMethod]
        public void CarregarListaDeServicosDoProjetoGerenteAcessandoProjetoDeOutroGerenteDeveRetornarView_ListaDeRecursosProjeto()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var usuarioGabriel = new Usuario(1, "Gabriel", "gabriel@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(new Projeto(1, "Guarana", usuarioGabriel, "Vonpar", "Java", new DateTime(), new DateTime(), 1000, 2, SituacaoProjeto.Novo));
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, null, null);
            // Act
            var result = projetoController.CarregarListaDeServicosDoProjeto(1);

            // Assert
            Assert.AreEqual("_ListaDeRecursosProjeto", result.ViewName);
        }

        [TestMethod]
        public void CarregarListaDeServicosDoProjetoGerenteDoSeuProjetoAcessandoDeveRetornarModelNaoNull()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var controleDeRecursoRepositorio = new Mock<IControleRecursoRepositorio>();
            var usuarioCassio = new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var projeto = new Projeto(1, "Guarana", usuarioCassio, "Vonpar", "Java", new DateTime(), new DateTime(2019, 12, 20), 1000, 2, SituacaoProjeto.Novo);
            var recurso = new Servico(1, "VM", 100, SituacaoRecurso.Disponivel, true, "Vitual Machinew", TipoServico.Servico);
            var listaControleDeRecurso = new List<ControleRecurso>()
            {
                new ControleRecurso(1,projeto, recurso, new DateTime(), new DateTime())
            };
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(projeto);
            controleDeRecursoRepositorio.Setup(c => c.ListarServico(projeto)).Returns(listaControleDeRecurso);
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, controleDeRecursoRepositorio.Object, null);
            // Act
            var result = projetoController.CarregarListaDeServicosDoProjeto(1);

            // Assert
            Assert.AreNotEqual(null, result.Model);
        }

        [TestMethod]
        public void CarregarListaDeServicosDoProjetoGerenteDoSeuProjetoAcessandoDeveRetornarView_ListaDeRecursosProjeto()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var controleDeRecursoRepositorio = new Mock<IControleRecursoRepositorio>();
            var usuarioCassio = new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var projeto = new Projeto(1, "Guarana", usuarioCassio, "Vonpar", "Java", new DateTime(), new DateTime(2019, 12, 20), 1000, 2, SituacaoProjeto.Novo);
            var recurso = new Servico(1, "VM", 100, SituacaoRecurso.Disponivel, true, "Vitual Machinew", TipoServico.Servico);
            var listaControleDeRecurso = new List<ControleRecurso>()
            {
                new ControleRecurso(1,projeto, recurso, new DateTime(), new DateTime())
            };
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(projeto);
            controleDeRecursoRepositorio.Setup(c => c.ListarServico(projeto)).Returns(listaControleDeRecurso);
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, controleDeRecursoRepositorio.Object, null);
            // Act
            var result = projetoController.CarregarListaDeServicosDoProjeto(1);

            // Assert
            Assert.AreEqual("_ListaDeRecursosProjeto", result.ViewName);
        }

        [TestMethod]
        public void ListaProjetosFiltradaUsuarioLogaEhGerenteESemFiltroDeveRetornarListaVazia()
        {
            // Arrange
            var usuarioCassio = new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var usuarioRepositorio = new Mock<IUsuarioRepositorio>();
            usuarioRepositorio.Setup(u => u.BuscarPorEmail("cassio@cwi.com.br")).Returns(usuarioCassio);
            projetoRepositorio.Setup(p => p.ListarPorGerente(usuarioCassio, "")).Returns(new List<Projeto>());
            var usuarioServico = new UsuarioServico(usuarioRepositorio.Object, new ServicoDeCriptografia());
            var projetoController = new ProjetoController(projetoRepositorio.Object, usuarioServico, null, null, null);
            // Act
            var result = projetoController.ListaProjetosFiltrada();
            //Assert 
            Assert.AreEqual(0, ((ListaProjetosModel)result.ViewData.Model).Projetos.Count);
        }

        [TestMethod]
        public void ListaProjetosFiltradaUsuarioLogaEhGerenteEComFiltroDeveRetornarListaVaziaPoisOMockEhVazio()
        {
            // Arrange
            var usuarioCassio = new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var usuarioRepositorio = new Mock<IUsuarioRepositorio>();
            usuarioRepositorio.Setup(u => u.BuscarPorEmail("cassio@cwi.com.br")).Returns(usuarioCassio);
            projetoRepositorio.Setup(p => p.ListarPorGerente(usuarioCassio, "cwi")).Returns(new List<Projeto>());
            var usuarioServico = new UsuarioServico(usuarioRepositorio.Object, new ServicoDeCriptografia());
            var projetoController = new ProjetoController(projetoRepositorio.Object, usuarioServico, null, null, null);
            // Act
            var result = projetoController.ListaProjetosFiltrada("cwi");
            //Assert 
            Assert.AreEqual(0, ((ListaProjetosModel)result.ViewData.Model).Projetos.Count);
        }

        [TestMethod]
        public void ListaProjetosFiltradaUsuarioLogaEhGerenteEComFiltroDeveRetornarListaCom1()
        {
            // Arrange
            var usuarioCassio = new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var usuarioRepositorio = new Mock<IUsuarioRepositorio>();
            var lista = new List<Projeto>()
            {
                new Projeto(1, "Guarana", usuarioCassio, "Vonpar", "Java", new DateTime(), new DateTime(2019, 12, 20), 1000, 2, SituacaoProjeto.Novo)
            };
            usuarioRepositorio.Setup(u => u.BuscarPorEmail("cassio@cwi.com.br")).Returns(usuarioCassio);
            projetoRepositorio.Setup(p => p.ListarPorGerente(usuarioCassio, "cwi")).Returns(lista);
            var usuarioServico = new UsuarioServico(usuarioRepositorio.Object, new ServicoDeCriptografia());
            var projetoController = new ProjetoController(projetoRepositorio.Object, usuarioServico, null, null, null);
            // Act
            var result = projetoController.ListaProjetosFiltrada("cwi");
            //Assert 
            Assert.AreEqual(1, ((ListaProjetosModel)result.ViewData.Model).Projetos.Count);
        }

        [TestMethod]
        public void CarregarListaDeCompartilhadosDoProjetoGerenteAcessandoProjetoDeOutroGerenteDeveRetornarModelNull()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var usuarioGabriel = new Usuario(1, "Gabriel", "gabriel@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(new Projeto(1, "Guarana", usuarioGabriel, "Vonpar", "Java", new DateTime(), new DateTime(), 1000, 2, SituacaoProjeto.Novo));
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, null, null);
            // Act
            var result = projetoController.CarregarListaDeCompartilhadosDoProjeto(1);

            // Assert
            Assert.AreEqual(null, result.Model);
        }

        [TestMethod]
        public void CarregarListaDeCompartilhadosDoProjetoGerenteAcessandoProjetoDeOutroGerenteDeveRetornarView_ListaDeRecursosProjeto()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var usuarioGabriel = new Usuario(1, "Gabriel", "gabriel@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(new Projeto(1, "Guarana", usuarioGabriel, "Vonpar", "Java", new DateTime(), new DateTime(), 1000, 2, SituacaoProjeto.Novo));
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, null, null);
            // Act
            var result = projetoController.CarregarListaDeCompartilhadosDoProjeto(1);

            // Assert
            Assert.AreEqual("_ListaDeRecursosProjeto", result.ViewName);
        }

        [TestMethod]
        public void CarregarListaDeCompartilhadosDoProjetoGerenteDoSeuProjetoAcessandoDeveRetornarModelNaoNull()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var controleDeRecursoRepositorio = new Mock<IControleRecursoRepositorio>();
            var usuarioCassio = new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var projeto = new Projeto(1, "Guarana", usuarioCassio, "Vonpar", "Java", new DateTime(), new DateTime(2019, 12, 20), 1000, 2, SituacaoProjeto.Novo);
            var recurso = new Compartilhado(0, "Internet", 100, SituacaoRecurso.Disponivel, true, "100.100.99.1", false, 0, 0, 0, false, false, TipoRecurso.Fisico);
            var listaControleDeRecurso = new List<ControleRecurso>()
            {
                new ControleRecurso(1,projeto, recurso, new DateTime(), new DateTime())
            };
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(projeto);
            controleDeRecursoRepositorio.Setup(c => c.ListarCompartilhado(projeto)).Returns(listaControleDeRecurso);
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, controleDeRecursoRepositorio.Object, null);
            // Act
            var result = projetoController.CarregarListaDeCompartilhadosDoProjeto(1);

            // Assert
            Assert.AreNotEqual(null, result.Model);
        }

        [TestMethod]
        public void CarregarListaDeCompartilhadosDoProjetoGerenteDoSeuProjetoAcessandoDeveRetornarView_ListaDeRecursosProjeto()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var controleDeRecursoRepositorio = new Mock<IControleRecursoRepositorio>();
            var usuarioCassio = new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var projeto = new Projeto(1, "Guarana", usuarioCassio, "Vonpar", "Java", new DateTime(), new DateTime(2019, 12, 20), 1000, 2, SituacaoProjeto.Novo);
            var recurso = new Compartilhado(0, "Internet", 100, SituacaoRecurso.Disponivel, true, "100.100.99.1", false, 0, 0, 0, false, false, TipoRecurso.Fisico);
            var listaControleDeRecurso = new List<ControleRecurso>()
            {
                new ControleRecurso(1,projeto, recurso, new DateTime(), new DateTime())
            };
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(projeto);
            controleDeRecursoRepositorio.Setup(c => c.ListarCompartilhado(projeto)).Returns(listaControleDeRecurso);
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, controleDeRecursoRepositorio.Object, null);
            // Act
            var result = projetoController.CarregarListaDeCompartilhadosDoProjeto(1);

            // Assert
            Assert.AreEqual("_ListaDeRecursosProjeto", result.ViewName);
        }

        [TestMethod]
        public void CarregarListaDePatrimoniosDoProjetoGerenteAcessandoProjetoDeOutroGerenteDeveRetornarModelNull()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var usuarioGabriel = new Usuario(1, "Gabriel", "gabriel@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(new Projeto(1, "Guarana", usuarioGabriel, "Vonpar", "Java", new DateTime(), new DateTime(), 1000, 2, SituacaoProjeto.Novo));
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, null, null);
            // Act
            var result = projetoController.CarregarListaDePatrimoniosDoProjeto(1);

            // Assert
            Assert.AreEqual(null, result.Model);
        }

        [TestMethod]
        public void CarregarListaDePatrimoniosDoProjetoGerenteAcessandoProjetoDeOutroGerenteDeveRetornarView_ListaDeRecursosProjeto()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var usuarioGabriel = new Usuario(1, "Gabriel", "gabriel@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(new Projeto(1, "Guarana", usuarioGabriel, "Vonpar", "Java", new DateTime(), new DateTime(), 1000, 2, SituacaoProjeto.Novo));
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, null, null);
            // Act
            var result = projetoController.CarregarListaDePatrimoniosDoProjeto(1);

            // Assert
            Assert.AreEqual("_ListaDeRecursosProjeto", result.ViewName);
        }

        [TestMethod]
        public void CarregarListaDePatrimoniosDoProjetoGerenteDoSeuProjetoAcessandoDeveRetornarModelNaoNull()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var controleDeRecursoRepositorio = new Mock<IControleRecursoRepositorio>();
            var usuarioCassio = new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var projeto = new Projeto(1, "Guarana", usuarioCassio, "Vonpar", "Java", new DateTime(), new DateTime(2019, 12, 20), 1000, 2, SituacaoProjeto.Novo);
            var recurso = new Patrimonio(1, "Notebook", 1000, SituacaoRecurso.Disponivel, true, "Dell n1", "Dell", new DateTime(), 1000, 1);
            var listaControleDeRecurso = new List<ControleRecurso>()
            {
                new ControleRecurso(1,projeto, recurso, new DateTime(), new DateTime())
            };
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(projeto);
            controleDeRecursoRepositorio.Setup(c => c.ListarPatrimonio(projeto)).Returns(listaControleDeRecurso);
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, controleDeRecursoRepositorio.Object, null);
            // Act
            var result = projetoController.CarregarListaDePatrimoniosDoProjeto(1);

            // Assert
            Assert.AreNotEqual(null, result.Model);
        }

        [TestMethod]
        public void CarregarListaDePatrimoniosDoProjetoGerenteDoSeuProjetoAcessandoDeveRetornarView_ListaDeRecursosProjeto()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var controleDeRecursoRepositorio = new Mock<IControleRecursoRepositorio>();
            var usuarioCassio = new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var projeto = new Projeto(1, "Guarana", usuarioCassio, "Vonpar", "Java", new DateTime(), new DateTime(2019, 12, 20), 1000, 2, SituacaoProjeto.Novo);
            var recurso = new Patrimonio(1, "Notebook", 1000, SituacaoRecurso.Disponivel, true, "Dell n1", "Dell", new DateTime(), 1000, 1);
            var listaControleDeRecurso = new List<ControleRecurso>()
            {
                new ControleRecurso(1,projeto, recurso, new DateTime(), new DateTime())
            };
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(projeto);
            controleDeRecursoRepositorio.Setup(c => c.ListarPatrimonio(projeto)).Returns(listaControleDeRecurso);
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, controleDeRecursoRepositorio.Object, null);
            // Act
            var result = projetoController.CarregarListaDePatrimoniosDoProjeto(1);

            // Assert
            Assert.AreEqual("_ListaDeRecursosProjeto", result.ViewName);
        }

        [TestMethod]
        public void CarregarListaDeRecursosDoProjetoGerenteAcessandoProjetoDeOutroGerenteDeveRetornarModelNull()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var usuarioGabriel = new Usuario(1, "Gabriel", "gabriel@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(new Projeto(1, "Guarana", usuarioGabriel, "Vonpar", "Java", new DateTime(), new DateTime(), 1000, 2, SituacaoProjeto.Novo));
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, null, null);
            // Act
            var result = projetoController.CarregarListaDeRecursosDoProjeto(1);

            // Assert
            Assert.AreEqual(null, result.Model);
        }

        [TestMethod]
        public void CarregarListaDeRecursosDoProjetoGerenteAcessandoProjetoDeOutroGerenteDeveRetornarView_ListaDeRecursosProjeto()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var usuarioGabriel = new Usuario(1, "Gabriel", "gabriel@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(new Projeto(1, "Guarana", usuarioGabriel, "Vonpar", "Java", new DateTime(), new DateTime(), 1000, 2, SituacaoProjeto.Novo));
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, null, null);
            // Act
            var result = projetoController.CarregarListaDeRecursosDoProjeto(1);

            // Assert
            Assert.AreEqual("_ListaDeRecursosProjeto", result.ViewName);
        }

        [TestMethod]
        public void CarregarListaDeRecursosDoProjetoGerenteDoSeuProjetoAcessandoDeveRetornarModelNaoNull()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var controleDeRecursoRepositorio = new Mock<IControleRecursoRepositorio>();
            var usuarioCassio = new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var projeto = new Projeto(1, "Guarana", usuarioCassio, "Vonpar", "Java", new DateTime(), new DateTime(2019, 12, 20), 1000, 2, SituacaoProjeto.Novo);
            var recurso = new Patrimonio(1, "Notebook", 1000, SituacaoRecurso.Disponivel, true, "Dell n1", "Dell", new DateTime(), 1000, 1);
            var listaControleDeRecurso = new List<ControleRecurso>()
            {
                new ControleRecurso(1,projeto, recurso, new DateTime(), new DateTime())
            };
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(projeto);
            controleDeRecursoRepositorio.Setup(c => c.Listar(projeto)).Returns(listaControleDeRecurso);
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, controleDeRecursoRepositorio.Object, null);
            // Act
            var result = projetoController.CarregarListaDeRecursosDoProjeto(1);

            // Assert
            Assert.AreNotEqual(null, result.Model);
        }

        [TestMethod]
        public void CarregarListaDeRecursosDoProjetoGerenteDoSeuProjetoAcessandoDeveRetornarView_ListaDeRecursosProjeto()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var controleDeRecursoRepositorio = new Mock<IControleRecursoRepositorio>();
            var usuarioCassio = new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var projeto = new Projeto(1, "Guarana", usuarioCassio, "Vonpar", "Java", new DateTime(), new DateTime(2019, 12, 20), 1000, 2, SituacaoProjeto.Novo);
            var recurso = new Patrimonio(1, "Notebook", 1000, SituacaoRecurso.Disponivel, true, "Dell n1", "Dell", new DateTime(), 1000, 1);
            var listaControleDeRecurso = new List<ControleRecurso>()
            {
                new ControleRecurso(1,projeto, recurso, new DateTime(), new DateTime())
            };
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(projeto);
            controleDeRecursoRepositorio.Setup(c => c.Listar(projeto)).Returns(listaControleDeRecurso);
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, controleDeRecursoRepositorio.Object, null);
            // Act
            var result = projetoController.CarregarListaDeRecursosDoProjeto(1);

            // Assert
            Assert.AreEqual("_ListaDeRecursosProjeto", result.ViewName);
        }
    }
}
