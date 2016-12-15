namespace ControleCustos.Dominio.Recurso.Interface
{
    public interface IRecursoRepositorio
    {
        Classe.Recurso Buscar(int id);
        void Inserir(Classe.Recurso recurso);
        void Atualizar(Classe.Recurso recurso);
    }
}