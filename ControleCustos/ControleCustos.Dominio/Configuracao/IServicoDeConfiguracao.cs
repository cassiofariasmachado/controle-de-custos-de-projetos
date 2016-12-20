using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCustos.Dominio.Configuracao
{
    public interface IServicoDeConfiguracao
    {
        decimal SaudeDoProjetoCritica { get; }
        decimal SaudeDoProjetoRegular { get; }
        decimal SaudeDoProjetoBoa { get; }
    }
}
