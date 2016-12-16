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
        public int Id { get; set; }

        public Projeto Projeto { get; private set; }

        public Recurso Recurso { get; private set; }

        public DateTime DataInicio { get; private set; }

        public DateTime DataFim { get; private set; }
    }
}
