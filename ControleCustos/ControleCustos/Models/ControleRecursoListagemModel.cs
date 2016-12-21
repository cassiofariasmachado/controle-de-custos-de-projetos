using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ControleCustos.Models
{
    public class ControleRecursoListagemModel
    {
        public IList<ControleRecursoModel> Recursos { get; set; }

        [DisplayName("Custo total previsto: ")]
        public decimal CustoTotalPrevisto { get; set; }

        public ControleRecursoListagemModel(IList<ControleRecursoModel> listaControleRecursoModel, decimal custoTotalPrevisto)
        {
            this.Recursos = listaControleRecursoModel;
            this.CustoTotalPrevisto = custoTotalPrevisto;
        }
    }
}