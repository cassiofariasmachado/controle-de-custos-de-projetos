using ControleCustos.Dominio.Recurso.Interface;
using ControleCustos.Dominio.Recurso.Classe;

namespace ControleCustos.Repositorio.RecursoRepositorio
{
    public class RecursoRepositorio : IRecursoRepositorio
    {
        public Recurso Buscar(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Recurso.Find(id);
            }
        }
    }
}
