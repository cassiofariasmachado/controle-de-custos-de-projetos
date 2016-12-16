using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCustos.Dominio
{
    public class ControleRecurso
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Projeto Projeto { get; set; }

        [Required]
        public Recurso Recurso { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }
    }
}
