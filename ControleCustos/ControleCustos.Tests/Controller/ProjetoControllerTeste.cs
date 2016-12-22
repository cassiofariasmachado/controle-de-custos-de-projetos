using ControleCustos.Controllers;
using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;
using ControleCustos.Dominio.Interface;
using ControleCustos.Infraestrutura;
using ControleCustos.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web;

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

        [TestMethod]
        public void CarregarModalGerenteAcessandoProjetoDeOutroGerenteDeveRetornarModalVazia()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var usuarioGabriel = new Usuario(1, "Gabriel", "gabriel@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var projeto = new Projeto(1, "Pepsi", usuarioGabriel, "Pepsi", "C#", new DateTime(), new DateTime(2019, 12, 20), 1000, 2, SituacaoProjeto.Novo);
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(projeto);
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, null, null, null);
            // Act
            var result = projetoController.CarregarModal(1, 1);
            // Assert
            Assert.AreEqual(null, ((ControleRecursoModel)result.ViewData.Model).NomeProjeto);
            Assert.AreEqual(0, ((ControleRecursoModel)result.ViewData.Model).IdProjeto);
            Assert.AreEqual(null, ((ControleRecursoModel)result.ViewData.Model).NomeRecurso);
            Assert.AreEqual(0, ((ControleRecursoModel)result.ViewData.Model).IdRecurso);
        }

        [TestMethod]
        public void CarregarModalGerenteAcessandoProjetoSeuGerenteDeveRetornarModalPopulada()
        {
            // Arrange
            var projetoRepositorio = new Mock<IProjetoRepositorio>();
            var recursoRepositorio = new Mock<IRecursoRepositorio>();
            var usuarioCassio = new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var projeto = new Projeto(1, "Pepsi", usuarioCassio, "Pepsi", "C#", new DateTime(), new DateTime(2019, 12, 20), 1000, 2, SituacaoProjeto.Novo);
            var recurso = new Patrimonio(1, "Teclado", 10, SituacaoRecurso.Indisponivel, true, "NS", "Asus", new DateTime(), 10, 1);
            recursoRepositorio.Setup(r => r.Buscar(1)).Returns(recurso);
            projetoRepositorio.Setup(p => p.Buscar(1)).Returns(projeto);
            var projetoController = new ProjetoController(projetoRepositorio.Object, null, recursoRepositorio.Object, null, null);
            // Act
            var result = projetoController.CarregarModal(1, 1);
            // Assert
            Assert.AreEqual("Teclado", ((ControleRecursoModel)result.ViewData.Model).NomeRecurso);
            Assert.AreEqual(1, ((ControleRecursoModel)result.ViewData.Model).IdRecurso);
            Assert.AreEqual("Pepsi", ((ControleRecursoModel)result.ViewData.Model).NomeProjeto);
            Assert.AreEqual(1, ((ControleRecursoModel)result.ViewData.Model).IdProjeto);
        }

        [TestMethod]
        public void CarregarListaDeServicosDeveRetornarView_ListagemServicoEModelPopulada()
        {
            // Arrange
            var recursoRepositorio = new Mock<IRecursoRepositorio>();
            var listaServico = new List<Servico>()
            {
                new Servico(1, "Git", 100, SituacaoRecurso.Disponivel, false, "GitKraken", TipoServico.Licenca) { },
                new Servico(2, "Netbeans", 1000, SituacaoRecurso.Disponivel, false, "NeatBeans Java", TipoServico.Servico) { },
                new Servico(3, "Visual Studio", 10000, SituacaoRecurso.Disponivel, false, "Microsoft", TipoServico.Licenca) { }
            };
            recursoRepositorio.Setup(r => r.BuscaPaginadaServicos(1, 5)).Returns(listaServico);
            var projetoController = new ProjetoController(null, null, recursoRepositorio.Object, null, null);
            // Act
            var result = projetoController.CarregarListaDeServicos(1);
            //Assert
            Assert.AreEqual("_ListagemServico", result.ViewName);
            Assert.AreNotEqual(null, result.Model);
        }

        [TestMethod]
        public void CarregarListaDePatrimoniosDeveRetornarView_ListagemServicoEModelPopulada()
        {
            // Arrange
            var recursoRepositorio = new Mock<IRecursoRepositorio>();
            var listaPatrimonio = new List<Patrimonio>()
            {
                new Patrimonio(1, "Teclado", 100, SituacaoRecurso.Indisponivel, false, "Asus", "Asus", new DateTime(), 1000, 10) { },
                new Patrimonio(2, "Notebook", 100, SituacaoRecurso.Indisponivel, false, "Asus", "Asus", new DateTime(), 1000, 10) { },
                new Patrimonio(0, "Violao", 100, SituacaoRecurso.Disponivel, true, "NS", "D", new DateTime(), 1000, 10) { }
        };
            recursoRepositorio.Setup(r => r.BuscaPaginadaPatrimonios(1, 5)).Returns(listaPatrimonio);
            var projetoController = new ProjetoController(null, null, recursoRepositorio.Object, null, null);
            // Act
            var result = projetoController.CarregarListaDePatrimonios(1);
            //Assert
            Assert.AreEqual("_ListagemPatrimonio", result.ViewName);
            Assert.AreNotEqual(null, result.Model);
        }

        [TestMethod]
        public void CarregarListaDeRecursosCompartilhadosDeveRetornarView_ListagemServicoEModelPopulada()
        {
            // Arrange
            var recursoRepositorio = new Mock<IRecursoRepositorio>();
            var listaCompartilhado = new List<Compartilhado>()
            {
                new Compartilhado(1, "VM", 10000, SituacaoRecurso.Indisponivel,true, "100.1.1.1", true,1000, 100, 10000, true, true, TipoRecurso.Fisico) { }
        };
            recursoRepositorio.Setup(r => r.BuscaPaginadaRecursoCompartilhados(1, 5)).Returns(listaCompartilhado);
            var projetoController = new ProjetoController(null, null, recursoRepositorio.Object, null, null);
            // Act
            var result = projetoController.CarregarListaDeRecursosCompartilhados(1);
            //Assert
            Assert.AreEqual("_ListagemCompartilhado", result.ViewName);
            Assert.AreNotEqual(null, result.Model);
        }
    }
}
