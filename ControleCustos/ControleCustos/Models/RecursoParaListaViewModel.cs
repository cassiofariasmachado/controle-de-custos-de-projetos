using ControleCustos.Dominio;

namespace ControleCustos.Models
{
    public class RecursoParaListaViewModel
    {
        public RecursoParaListaViewModel(Recurso recurso)
        {
            this.Id = recurso.Id;
            this.Nome = recurso.Nome;
        }

        public int Id { get; private set; }

        public string Nome { get; private set; }
    }
}