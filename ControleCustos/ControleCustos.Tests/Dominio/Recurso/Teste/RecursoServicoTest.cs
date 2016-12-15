using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControleCustos.Dominio.Recurso;
using FakeItEasy;
using ControleCustos.Dominio.Recurso.Interface;

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
    }
}
