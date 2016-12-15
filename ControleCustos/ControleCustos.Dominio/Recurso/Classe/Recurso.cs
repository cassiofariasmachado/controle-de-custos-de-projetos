using ControleCustos.Dominio.Recurso.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Dominio.Recurso.Classe
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
        public ICollection<Projeto.Projeto> Recursos { get; set; }

        public Recurso()
        {
            this.Recursos = new List<Projeto.Projeto>();
        }
    }
}
