using System.Collections.Generic;

namespace ControleCustos.Models
{
    public class ControleRecursoListagemModel
    {
        public IList<ControleRecursoModel> Recursos { get; set; }

        public ControleRecursoListagemModel(IList<ControleRecursoModel> listaControleRecursoModel)
        {
            this.Recursos = listaControleRecursoModel;
        }
    }
}