using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleCustos.Models
{
    public class ServicoModel : RecursoModel
    {
        public TipoServico TipoServico { get; set; }

        public ServicoModel(Servico servico)
            : base (servico)
        {
            this.TipoServico = servico.TipoServico;
        }
    }
}