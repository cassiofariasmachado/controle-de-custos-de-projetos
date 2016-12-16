using ControleCustos.Dominio.Enum;
using ControleCustos.Dominio.Interface;

namespace ControleCustos.Dominio
{
    public class ProjetoServico
    {
        IProjetoRepositorio projetoServico;

        public ProjetoServico(IProjetoRepositorio projetoServico)
        {
            this.projetoServico = projetoServico;
        }

        public Projeto Buscar(int id)
        {
            return this.projetoServico.Buscar(id);
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
                this.projetoServico.Inserir(projeto);
            }
            else
            {
                this.projetoServico.Atualizar(projeto);
            }
        }
    }
}
