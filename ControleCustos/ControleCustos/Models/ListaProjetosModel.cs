using ControleCustos.Dominio;
using ControleCustos.Infraestrutura;
using System;
using System.Collections.Generic;

namespace ControleCustos.Models
{
    public class ListaProjetosModel
    {
        public IList<ProjetoDetalheModel> Projetos { get; set; }

        public decimal LimiteSaudeBoaRegular { get; set; }

        public decimal LimiteSaudeRegularCritica { get; set; }


        public ListaProjetosModel(IList<Projeto> projetos, ServicoDeConfiguracao configuracao, CalculoServico calculoServico)
        {
            this.Projetos = this.ConverterEmListagemDeProjetos(projetos, calculoServico);
            this.LimiteSaudeBoaRegular = configuracao.LimiteSaudeBoaRegular;
            this.LimiteSaudeRegularCritica = configuracao.LimiteSaudeRegularCritica;
        }

        private IList<ProjetoDetalheModel> ConverterEmListagemDeProjetos(IList<Projeto> projetos, CalculoServico calculoServico)
        {
            IList<ProjetoDetalheModel> model = new List<ProjetoDetalheModel>();

            foreach (var projeto in projetos)
            {
                model.Add(new ProjetoDetalheModel(projeto, calculoServico.CalcularCustoPercentual(projeto, DateTime.Now)));
            }

            return model;
        }
    }
}