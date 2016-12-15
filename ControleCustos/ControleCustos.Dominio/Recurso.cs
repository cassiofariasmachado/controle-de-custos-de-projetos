using ControleCustos.Dominio.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Dominio
{
    public abstract class Recurso
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public TipoRecurso TipoRecurso { get; set; }

        [Required]
        public decimal ValorMensal { get; set; }

        [Required]
        public SituacaoRecurso Situacao { get; set; }

        [Required]
        public ICollection<Projeto> Recursos { get; set; }

        public Recurso()
        {
            this.Recursos = new List<Projeto>();
        }
    }
}
