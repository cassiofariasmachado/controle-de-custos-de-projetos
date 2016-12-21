using ControleCustos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleCustos.Models
{
    public class PatrimonioListagemModel : RecursoListagemModel
    {
        public IList<PatrimonioModel> Patrimonios { get; set; }

        public PatrimonioListagemModel(IList<Patrimonio> patrimonios, int paginaAtual, int quantidadePorPagina, int quantidadeTotalRecursos)
            : base(paginaAtual, quantidadePorPagina, quantidadeTotalRecursos)
        {
            this.Patrimonios = this.ConverterEmListagemDePatrimonios(patrimonios);
        }

        private IList<PatrimonioModel> ConverterEmListagemDePatrimonios(IList<Patrimonio> patrimonios)
        {
            IList<PatrimonioModel> model = new List<PatrimonioModel>();
            foreach (var patrimonio in patrimonios)
            {
                model.Add(new PatrimonioModel(patrimonio));
            }
            return model;
        }
    }
}