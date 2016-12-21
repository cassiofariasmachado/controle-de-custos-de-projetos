using ControleCustos.Dominio.Configuracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ControleCustos.Infraestrutura
{
    public class ServicoDeConfiguracao : IServicoDeConfiguracao
    {
        private decimal limiteSaudeBoaRegular = Convert.ToDecimal(WebConfigurationManager.AppSettings["LimiteSaudeBoaRegular"]);
        private decimal limiteSaudeRegularCritica = Convert.ToDecimal(WebConfigurationManager.AppSettings["LimiteSaudeRegularCritica"]);

        public decimal LimiteSaudeBoaRegular
        {
            get
            {
                return this.limiteSaudeBoaRegular;
            }
        }

        public decimal LimiteSaudeRegularCritica
        {
            get
            {
                return this.limiteSaudeRegularCritica;
            }
        }
    }
}