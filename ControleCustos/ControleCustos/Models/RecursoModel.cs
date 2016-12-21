using ControleCustos.Dominio;

namespace ControleCustos.Models
{
    public class RecursoModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal ValorMensal { get; set; }

        public RecursoModel(Recurso recurso)
        {
            this.Id = recurso.Id;
            this.Nome = recurso.Nome;
            this.ValorMensal = recurso.ValorMensal;
        }
    }
}