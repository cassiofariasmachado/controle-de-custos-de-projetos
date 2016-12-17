using System.Collections.Generic;

namespace ControleCustos.Dominio.Interface
{
    public interface IRecursoRepositorio
    {
        Recurso Buscar(int id);
        void Inserir(Recurso recurso);
        void Atualizar(Recurso recurso);
        IList<Recurso> BuscaPaginadaRecursoCompartilhados(int pagina, int quantidade);
        IList<Recurso> BuscaPaginadaPatrimonios(int pagina, int quantidade);
        IList<Recurso> BuscaPaginadaServicos(int pagina, int quantidade);
    }
}