using System.Collections.Generic;

namespace ControleCustos.Dominio.Interface
{
    public interface IRecursoRepositorio
    {
        Recurso Buscar(int id);
        void Inserir(Recurso recurso);
        void Atualizar(Recurso recurso);
        IList<Compartilhado> BuscaPaginadaRecursoCompartilhados(int pagina, int quantidade);
        IList<Patrimonio> BuscaPaginadaPatrimonios(int pagina, int quantidade);
        IList<Servico> BuscaPaginadaServicos(int pagina, int quantidade);
        int CompartilhadoCount();
        int ServicoCount();
        int PatrimonioCount();
    }
}