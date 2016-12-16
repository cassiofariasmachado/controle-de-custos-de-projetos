using ControleCustos.Dominio.Enum;
using ControleCustos.Dominio.Interface;

namespace ControleCustos.Dominio
{
    public class ProjetoServico
    {
        IProjetoRepositorio projetoRepositorio;

        public ProjetoServico(IProjetoRepositorio projetoRepositorio)
        {
            this.projetoRepositorio = projetoRepositorio;
        }

        public Projeto Buscar(int id)
        {
            return this.projetoRepositorio.Buscar(id);
        }

        public void Salvar(Projeto projeto)
        {
            if (projeto.Id == 0)
            {
                Usuario gerente = new Usuario();
                gerente.Id = 1;
                gerente.Nome = "Gerente";
                gerente.Email = "gerente@cwi.com.br";
                gerente.Senha = "740d9c49b11f3ada7b9112614a54be41";
                gerente.Permissao = Permissao.Gerente;
                projeto.Gerente = gerente;
                projeto.DataFinalRealizada = null;
                this.projetoRepositorio.Inserir(projeto);
            }
            else
            {
                this.projetoRepositorio.Atualizar(projeto);
            }
        }

        private void ValidarProjeto(Projeto projeto)
        {
            ValidarNome(projeto);
            ValidarCliente(projeto);
            ValidarTecnologia(projeto);
            ValidarDataInicio(projeto);
            ValidarDataFinalPrevista(projeto);
            ValidarFaturamentoPrevisto(projeto);
            ValidarNumeroProfissionais(projeto);
        }

        private void ValidarNome(Projeto projeto)
        {
            if (projeto.Nome.Length > 50)
            {
                throw new ProjetoException("O nome do projeto não pode ser maior que 50.");
            }

            if (projeto.Nome.Length < 5)
            {
                throw new ProjetoException("O nome do projeto não pode ser menor do que 5.");
            }
        }

        private void ValidarCliente(Projeto projeto)
        {
            if (projeto.Cliente.Length > 50)
            {
                throw new ProjetoException("O nome do cliente não pode ser maior que 50.");
            }

            if (projeto.Cliente.Length < 3)
            {
                throw new ProjetoException("O nome do cliente não pode ser menor do que 3.");
            }
        }

        private void ValidarTecnologia(Projeto projeto)
        {
            if (projeto.Tecnologia.Length > 50)
            {
                throw new ProjetoException("O nome da tecnologia não pode ser maior que 50.");
            }
        }

        private void ValidarDataInicio(Projeto projeto)
        {
            if (projeto.DataInicio == null)
            {
                throw new ProjetoException("A data de início não pode ser nula.");
            }
        }

        private void ValidarDataFinalPrevista(Projeto projeto)
        {
            if (projeto.DataFinalPrevista == null)
            {
                throw new ProjetoException("A data final prevista não pode ser nula.");
            }
        }

        private void ValidarFaturamentoPrevisto(Projeto projeto)
        {
            if (projeto.FaturamentoPrevisto <= 0)
            {
                throw new ProjetoException("O faturamento previsto deve ser maior que zero.");
            }
        }

        private void ValidarNumeroProfissionais(Projeto projeto)
        {
            if (projeto.NumeroDeProfissionais <= 0)
            {
                throw new ProjetoException("O número de profissionais deve ser maior que zero.");
            }
        }
    }
}
