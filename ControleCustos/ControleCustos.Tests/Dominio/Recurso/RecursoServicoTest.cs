using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControleCustos.Dominio.Recurso;
using FakeItEasy;
using ControleCustos.Dominio.Recurso.Interface;
using ControleCustos.Dominio.Recurso.Classe;

namespace ControleCustos.Tests.Dominio.Recurso
{
    [TestClass]
    public class RecursoServicoTest
    {
        [TestMethod]
        public void BuscarDeveChamarBuscarRepositorio()
        {
            IRecursoRepositorio repositorio = A.Fake<IRecursoRepositorio>();
            RecursoServico servico = new RecursoServico(repositorio);

            servico.Buscar(1);

            A.CallTo(() => repositorio.Buscar(1)).MustHaveHappened();
        }

        [TestMethod]
        public void BuscarDeveRetornarNullQuandoNaoEncontrar()
        {
            IRecursoRepositorio repositorio = A.Fake<IRecursoRepositorio>();
            RecursoServico servico = new RecursoServico(repositorio);

            A.CallTo(() => repositorio.Buscar(1)).Returns(null);

            servico.Buscar(1);

            Assert.IsNull(servico.Buscar(1));
        }

        [TestMethod]
        public void SalvarDeveAdicionarRecurso()
        {
            IRecursoRepositorio repositorio = A.Fake<IRecursoRepositorio>();
            RecursoServico servico = new RecursoServico(repositorio);

            var recurso = new RecursoCompartilhado();
            servico.Salvar(recurso);

            A.CallTo(() => repositorio.Inserir(recurso)).MustHaveHappened();
        }

        [TestMethod]
        public void SalvarDeveAtualizarRecurso()
        {
            IRecursoRepositorio repositorio = A.Fake<IRecursoRepositorio>();
            RecursoServico servico = new RecursoServico(repositorio);

            var recurso = new RecursoCompartilhado();
            recurso.Id = 1;
            servico.Salvar(recurso);

            A.CallTo(() => repositorio.Atualizar(recurso)).MustHaveHappened();
        }
    }
}
