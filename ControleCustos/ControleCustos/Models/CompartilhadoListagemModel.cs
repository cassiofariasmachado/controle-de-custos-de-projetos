using ControleCustos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleCustos.Models
{
    public class CompartilhadoListagemModel : RecursoListagemModel
    {
        public IList<CompartilhadoModel> Compartilhados { get; set; }

        public CompartilhadoListagemModel(IList<Compartilhado> compartilhados, int paginaAtual, int quantidadePorPagina, int quantidadeTotalRecursos)
            : base (paginaAtual, quantidadePorPagina, quantidadeTotalRecursos)
        {
            this.Compartilhados = this.ConverterEmListagemDeCompartilhados(compartilhados);
        }

        private IList<CompartilhadoModel> ConverterEmListagemDeCompartilhados(IList<Compartilhado> compartilhados)
        {
            IList<CompartilhadoModel> model = new List<CompartilhadoModel>();
            foreach (var compartilhado in compartilhados)
            {
                model.Add(new CompartilhadoModel(compartilhado));
            }
            return model;
        }
    }
}