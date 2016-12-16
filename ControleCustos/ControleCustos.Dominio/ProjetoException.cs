using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCustos.Dominio
{
    public class ProjetoException : Exception
    {
        public ProjetoException(string mensagem) : base(mensagem)
        {

        }
    }
}
