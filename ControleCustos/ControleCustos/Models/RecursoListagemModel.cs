using ControleCustos.Dominio;
using System.Collections.Generic;

namespace ControleCustos.Models
{
    public class RecursoListagemModel
    {
        public RecursoListagemModel(IList<Recurso> recursos, int quantidadeTotalRecursos)
        {
            this.Recursos = this.ConverterEmListagemDeRecursos(recursos);
            this.QuantidadeTotalRecursos = quantidadeTotalRecursos;
        }

        public int PaginaAtual { get; set; }
        public int QuantidadeDeRecursosPorPagina { get; set; }
        private int QuantidadeTotalRecursos { get; set; }

        public bool UltimaPagina
        {
            get
            {
                if (PaginaAtual >= QuantidadeTotalRecursos / (double)QuantidadeDeRecursosPorPagina)
                {
                    return true;
                }
                return false;
            }
        }

        public IList<RecursoModel> Recursos { get; set; }

        private IList<RecursoModel> ConverterEmListagemDeRecursos(IList<Recurso> recursos)
        {
            IList<RecursoModel> model = new List<RecursoModel>();

            foreach (var recurso in recursos)
            {
                model.Add(new RecursoModel(recurso));
            }

            return model;
        }
    }
}