using ControleCustos.Dominio;
using System.Collections.Generic;

namespace ControleCustos.Models
{
    public class RecursoListagemModel
    {
        public RecursoListagemModel(IList<Recurso> recursos)
        {
            this.Recursos = this.ConverterEmListagemDeRecursos(recursos);
        }

        public int PaginaAtual { get; set; }
        public int QuantidadeDeRecursosPorPagina { get; set; }

        public bool UltimaPagina
        {
            get
            {
                return Recursos.Count < this.QuantidadeDeRecursosPorPagina;
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