using System.Collections.Generic;

namespace ControleCustos.Dominio.Interface
{
    public interface IRecursoRepositorio
    {
        Recurso Buscar(int id);
        void Inserir(Recurso recurso);
        void Atualizar(Recurso recurso);
        IList<T> BuscarRecursosPaginados<T>(int pagina, int quantidade) where T : Recurso;
        int BuscarQuantidadeRecursos<T>() where T : Recurso;
    }
}