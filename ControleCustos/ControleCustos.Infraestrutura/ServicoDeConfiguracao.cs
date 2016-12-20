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
        private decimal saudeDoProjetoCritica = Convert.ToDecimal(WebConfigurationManager.AppSettings["SaudeDoProjetoCritica"]);
        private decimal saudeDoProjetoRegular = Convert.ToDecimal(WebConfigurationManager.AppSettings["SaudeDoProjetoRegular"]);
        private decimal saudeDoProjetoBoa = Convert.ToDecimal(WebConfigurationManager.AppSettings["SaudeDoProjetoBoa"]);

        public decimal SaudeDoProjetoCritica
        {
            get
            {
                return this.saudeDoProjetoCritica;
            }
        }

        public decimal SaudeDoProjetoRegular
        {
            get
            {
                return this.saudeDoProjetoRegular;
            }
        }

        public decimal SaudeDoProjetoBoa
        {
            get
            {
                return this.saudeDoProjetoBoa;
            }
        }
    }
}