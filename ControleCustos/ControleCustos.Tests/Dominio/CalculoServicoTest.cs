using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ControleCustos.Tests.Dominio
{
    [TestClass]
    public class CalculoServicoTest
    {
        ControleRecursoRepositorioMock controleRecursoRepositorio = new ControleRecursoRepositorioMock();

        [TestMethod]
        public void CalcularCustoTotalDeveRetornarOCustoTotalDeProjetoComApenasUmRecurso()
        {
            Projeto projeto = new Projeto(1, "Coca-cola", new Usuario(), "Coca-cola", "C#", new DateTime(2016, 11, 1), new DateTime(2016, 12, 5), 1000M, 12, SituacaoProjeto.Novo);

            CalculoServico calculoServico = new CalculoServico(controleRecursoRepositorio);

            decimal custoTotal = calculoServico.CalcularCustoTotalAte(projeto, new DateTime(2016, 12, 6));

            Assert.AreEqual(73.3D, (double)custoTotal, 0.1D);
        }

        [TestMethod]
        public void CalcularCustoTotalDeveRetornarOCustoTotalDeProjetoComDoisRecursos()
        {
            Projeto projeto = new Projeto(2, "Sicredi", new Usuario(), "Sicredi", "Java", new DateTime(2016, 11, 1), new DateTime(2016, 12, 5), 1000M, 12, SituacaoProjeto.Novo);

            CalculoServico calculoServico = new CalculoServico(controleRecursoRepositorio);

            decimal custoTotal = calculoServico.CalcularCustoTotalAte(projeto, new DateTime(2016, 12, 6));

            Assert.AreEqual(316.6D, (double)custoTotal, 0.1D);
        }

        [TestMethod]
        public void CalcularCustoTotalNaoDeveConsiderarRecursosForaDoPeriodo()
        {
            Projeto projeto = new Projeto(2, "Sicredi", new Usuario(), "Sicredi", "Java", new DateTime(2016, 11, 1), new DateTime(2016, 12, 5), 1000M, 12, SituacaoProjeto.Novo);


            CalculoServico calculoServico = new CalculoServico(controleRecursoRepositorio);

            decimal custoTotal = calculoServico.CalcularCustoTotalAte(projeto, new DateTime(2016, 11, 2));

            Assert.AreEqual(33.3D, (double)custoTotal, 0.1D);
        }

        [TestMethod]
        public void CalcularCustoMensalDeveRetornarCustoTotalDoMesInformado()
        {
            Projeto projeto = new Projeto(2, "Sicredi", new Usuario(), "Sicredi", "Java", new DateTime(2016, 11, 1), new DateTime(2016, 12, 5), 1000M, 12, SituacaoProjeto.Novo);

            CalculoServico calculoServico = new CalculoServico(controleRecursoRepositorio);

            decimal custoTotal = calculoServico.CalcularCustoMensal(projeto, 11, 2016);

            Assert.AreEqual(300D, (double)custoTotal, 0.1D);
        }

        [TestMethod]
        public void CalcularCustoMensalDeveRetornarCustoTotalDoMesInformadoDesconsiderandoRecursosForaDoPeriodo()
        {
            Projeto projeto = new Projeto(2, "Sicredi", new Usuario(), "Sicredi", "Java", new DateTime(2016, 11, 1), new DateTime(2016, 12, 5), 1000M, 12, SituacaoProjeto.Novo);

            CalculoServico calculoServico = new CalculoServico(controleRecursoRepositorio);

            decimal custoTotal = calculoServico.CalcularCustoMensal(projeto, 11, 2016);

            Assert.AreEqual(300D, (double)custoTotal, 0.1D);
        }

        [TestMethod]
        public void CalcularCustoPercentualDeveRetornarPercentualDeProjetoComApenasUmRecurso()
        {
            Projeto projeto = new Projeto(1, "Coca-cola", new Usuario(), "Coca-cola", "C#", new DateTime(2016, 11, 1), new DateTime(2016, 12, 5), 1000M, 12, SituacaoProjeto.Novo);

            CalculoServico calculoServico = new CalculoServico(controleRecursoRepositorio);

            decimal custoPercentual = calculoServico.CalcularCustoPercentual(projeto, new DateTime(2016, 12, 6));

            Assert.AreEqual(7.33D, (double)custoPercentual, 0.1D);
        }

        [TestMethod]
        public void CalcularCustoPercentualDeveRetornarPercentualDeProjetoComDoisRecursos()
        {
            Projeto projeto = new Projeto(2, "Sicredi", new Usuario(), "Sicredi", "Java", new DateTime(2016, 11, 1), new DateTime(2016, 12, 5), 1000M, 12, SituacaoProjeto.Novo);

            CalculoServico calculoServico = new CalculoServico(controleRecursoRepositorio);

            decimal custoPercentual = calculoServico.CalcularCustoPercentual(projeto, new DateTime(2016, 12, 6));

            Assert.AreEqual(31.66, (double)custoPercentual, 0.1D);
        }

        [TestMethod]
        public void CalcularCustoPercentualNaoDeveConsiderarRecursosForaDoPeriodo()
        {
            Projeto projeto = new Projeto(2, "Sicredi", new Usuario(), "Sicredi", "Java", new DateTime(2016, 11, 1), new DateTime(2016, 12, 5), 1000M, 12, SituacaoProjeto.Novo);

            CalculoServico calculoServico = new CalculoServico(controleRecursoRepositorio);

            decimal custoPercentual = calculoServico.CalcularCustoPercentual(projeto, new DateTime(2016, 11, 2));

            Assert.AreEqual(3.3, (double)custoPercentual, 0.1D);
        }
    }
}
