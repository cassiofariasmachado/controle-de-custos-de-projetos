using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using ControleCustos.Dominio.Interface;
using ControleCustos.Dominio;
using ControleCustos.Servicos;

namespace ControleCustos.Tests.Dominio
{
    [TestClass]
    public class RecursoServicoTest
    {
        [TestMethod]
        public void BuscarDeveChamarBuscarDoRepositorio()
        {
            IRecursoRepositorio repositorio = A.Fake<IRecursoRepositorio>();
            RecursoServico servico = new RecursoServico(repositorio, new ServicoDeConfiguracao());

            servico.Buscar(1);

            A.CallTo(() => repositorio.Buscar(1)).MustHaveHappened();
        }

        [TestMethod]
        public void BuscarDeveRetornarNullQuandoNaoEncontrar()
        {
            IRecursoRepositorio repositorio = A.Fake<IRecursoRepositorio>();
            RecursoServico servico = new RecursoServico(repositorio, new ServicoDeConfiguracao());

            A.CallTo(() => repositorio.Buscar(1)).Returns(null);

            servico.Buscar(1);

            Assert.IsNull(servico.Buscar(1));
        }

        [TestMethod]
        public void SalvarDeveAdicionarRecurso()
        {
            IRecursoRepositorio repositorio = A.Fake<IRecursoRepositorio>();
            RecursoServico servico = new RecursoServico(repositorio, new ServicoDeConfiguracao());

            var recurso = new RecursoCompartilhado();
            servico.Salvar(recurso);

            A.CallTo(() => repositorio.Inserir(recurso)).MustHaveHappened();
        }

        [TestMethod]
        public void SalvarDeveAtualizarRecurso()
        {
            IRecursoRepositorio repositorio = A.Fake<IRecursoRepositorio>();
            RecursoServico servico = new RecursoServico(repositorio, new ServicoDeConfiguracao());

            var recurso = new RecursoCompartilhado();
            recurso.Id = 1;
            servico.Salvar(recurso);

            A.CallTo(() => repositorio.Atualizar(recurso)).MustHaveHappened();
        }
    }
}
