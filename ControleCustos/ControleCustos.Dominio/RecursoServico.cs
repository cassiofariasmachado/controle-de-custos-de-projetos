using ControleCustos.Dominio.Interface;

namespace ControleCustos.Dominio
{
    public class RecursoServico
    {
        IRecursoRepositorio recursoRepositorio;

        public RecursoServico(IRecursoRepositorio recursoRepositorio)
        {
            this.recursoRepositorio = recursoRepositorio;
        }

        public Recurso Buscar(int id)
        {
            return recursoRepositorio.Buscar(id);
        }

        public void Salvar(Recurso recurso)
        {
            if (recurso.Id == 0)
            {
                recursoRepositorio.Inserir(recurso);
            } else
            {
                recursoRepositorio.Atualizar(recurso);
            }
        }
    }
}
