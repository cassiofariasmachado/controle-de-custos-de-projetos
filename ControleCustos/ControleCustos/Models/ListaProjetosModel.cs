using ControleCustos.Dominio;
using System.Collections.Generic;

namespace ControleCustos.Models
{
    public class ListaProjetosModel
    {
        public ListaProjetosModel(IList<Projeto> projetos)
        {
            this.Projetos = this.ConverterEmListagemDeProjetos(projetos);
        }

        public IList<ProjetoModel> Projetos { get; set; }

        private IList<ProjetoModel> ConverterEmListagemDeProjetos(IList<Projeto> projetos)
        {
            IList<ProjetoModel> model = new List<ProjetoModel>();

            foreach (var projeto in projetos)
            {
                model.Add(new ProjetoModel(projeto));
            }

            return model;
        }
    }
}