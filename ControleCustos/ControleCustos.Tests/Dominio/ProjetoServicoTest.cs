using ControleCustos.Dominio;
using ControleCustos.Dominio.Interface;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleCustos.Tests.Dominio
{
    [TestClass]
    public class ProjetoServicoTest
    {
        [TestMethod]
        public void BuscarDeveChamarBuscarDoRepositorio()
        {
            IProjetoRepositorio repositorio = A.Fake<IProjetoRepositorio>();
            ProjetoServico servico = new ProjetoServico(repositorio);

            servico.Buscar(1);

            A.CallTo(() => repositorio.Buscar(1)).MustHaveHappened();
        }

        [TestMethod]
        public void BuscarDeveRetornarNullQuandoNaoEncontrar()
        {
            IProjetoRepositorio repositorio = A.Fake<IProjetoRepositorio>();
            ProjetoServico servico = new ProjetoServico(repositorio);

            A.CallTo(() => repositorio.Buscar(1)).Returns(null);

            servico.Buscar(1);

            Assert.IsNull(servico.Buscar(1));
        }

        [TestMethod]
        public void SalvarDeveAdicionarRecurso()
        {
            IProjetoRepositorio repositorio = A.Fake<IProjetoRepositorio>();
            ProjetoServico servico = new ProjetoServico(repositorio);

            var projeto = new Projeto();
            servico.Salvar(projeto);

            A.CallTo(() => repositorio.Inserir(projeto)).MustHaveHappened();
        }

        [TestMethod]
        public void SalvarDeveAtualizarRecurso()
        {
            IProjetoRepositorio repositorio = A.Fake<IProjetoRepositorio>();
            ProjetoServico servico = new ProjetoServico(repositorio);

            var projeto = new Projeto();
            projeto.Id = 1;
            servico.Salvar(projeto);

            A.CallTo(() => repositorio.Atualizar(projeto)).MustHaveHappened();
        }
    }
}
