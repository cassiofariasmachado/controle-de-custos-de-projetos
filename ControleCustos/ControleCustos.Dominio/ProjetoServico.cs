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
                this.projetoServico.Inserir(projeto);
            }
            else
            {
                this.projetoServico.Atualizar(projeto);
            }
        }
    }
}
