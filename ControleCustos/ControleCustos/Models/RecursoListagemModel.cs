using ControleCustos.Dominio;
using System.Collections.Generic;

namespace ControleCustos.Models
{
    public class RecursoListagemModel
    {
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

        public RecursoListagemModel(int paginaAtual, int quantidadePorPagina, int quantidadeTotalRecursos)
        {
            this.PaginaAtual = paginaAtual;
            this.QuantidadeDeRecursosPorPagina = quantidadePorPagina;
            this.QuantidadeTotalRecursos = quantidadeTotalRecursos;
        }
    }
}