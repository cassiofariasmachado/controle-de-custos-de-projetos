using ControleCustos.Dominio;
using System.Collections.Generic;

namespace ControleCustos.Models
{
    public class RecursoListagemViewModel
    {
        public RecursoListagemViewModel(IList<Recurso> recursos)
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

        public IList<RecursoParaListaViewModel> Recursos { get; set; }

        private IList<RecursoParaListaViewModel> ConverterEmListagemDeRecursos(IList<Recurso> recursos)
        {
            IList<RecursoParaListaViewModel> model = new List<RecursoParaListaViewModel>();

            foreach (var recurso in recursos)
            {
                model.Add(new RecursoParaListaViewModel(recurso));
            }

            return model;
        }
    }
}