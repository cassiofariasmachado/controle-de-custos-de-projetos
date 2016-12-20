using ControleCustos.Dominio.Enum;
using System.Collections.Generic;

namespace ControleCustos.Dominio.Interface
{
    public interface IProjetoRepositorio
    {
        Projeto Buscar(int id);
        IList<Projeto> ListarProjetosAtivos();
        IList<Projeto> ListarProjetosEncerrados();
        void Inserir(Projeto projeto);
        void Atualizar(Projeto projeto);
        IList<Projeto> ListarPorGerente(Usuario gerente, string filtro);
        IList<Projeto> Listar(string filtro);
    }
}
