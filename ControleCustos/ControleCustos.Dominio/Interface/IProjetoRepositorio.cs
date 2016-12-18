using System.Collections;
using System.Collections.Generic;

namespace ControleCustos.Dominio.Interface
{
    public interface IProjetoRepositorio
    {
        Projeto Buscar(int id);
        void Inserir(Projeto projeto);
        void Atualizar(Projeto projeto);
        IList<Projeto> ListarPorGerente(Usuario gerente);
        IList<Projeto> Listar();
    }
}
