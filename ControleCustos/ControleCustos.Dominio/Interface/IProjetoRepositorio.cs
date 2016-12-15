namespace ControleCustos.Dominio.Interface
{
    public interface IProjetoRepositorio
    {
        Projeto Buscar(int id);
        void Inserir(Projeto projeto);
        void Atualizar(Projeto projeto);
    }
}
