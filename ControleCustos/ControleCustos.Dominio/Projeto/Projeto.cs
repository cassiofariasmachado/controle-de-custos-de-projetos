using ControleCustos.Dominio.UsuarioDominio.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCustos.Dominio.Projeto
{
    public class Projeto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Usuario Gerente { get; set; }

        public string Cliente { get; set; }

        public string Tecnologia { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFinalPrevista { get; set; }

        public DateTime DataFinalRealizada { get; set; }

        public double FaturamentoPrevisto { get; set; }

        public double FaturamentoRealizado { get; set; }

        public int NumeroDeProfissionais { get; set; }

        public Situacao Situacao { get; set; }
    }
}
