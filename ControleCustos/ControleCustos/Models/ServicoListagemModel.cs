using ControleCustos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleCustos.Models
{
    public class ServicoListagemModel : RecursoListagemModel
    {
        public IList<ServicoModel> Servicos { get; set; }

        public ServicoListagemModel(IList<Servico> servicos, int paginaAtual, int quantidadePorPagina, int quantidadeTotalRecursos)
            : base(paginaAtual, quantidadePorPagina, quantidadeTotalRecursos)
        {
            this.Servicos = this.ConverterEmListagemDeServicos(servicos);
        }

        private IList<ServicoModel> ConverterEmListagemDeServicos(IList<Servico> servicos)
        {
            IList<ServicoModel> model = new List<ServicoModel>();
            foreach (var servico in servicos)
            {
                model.Add(new ServicoModel(servico));
            }
            return model;
        }
    }
}