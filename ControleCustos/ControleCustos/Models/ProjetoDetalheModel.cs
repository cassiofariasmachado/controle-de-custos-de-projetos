using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;
using ControleCustos.Infraestrutura;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Models
{
    public class ProjetoDetalheModel
    {

        public int? Id { get; set; }

        [DisplayName("Nome do projeto")]
        public string Nome { get; set; }

        public Usuario Gerente { get; set; }

        [DisplayName("Cliente")]
        public string Cliente { get; set; }

        [DisplayName("Principal tecnologia")]
        public string Tecnologia { get; set; }

        [DisplayName("Data de início")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; }

        [DisplayName("Data final prevista")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFinalPrevista { get; set; }

        [DisplayName("Data final realizada")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataFinalRealizada { get; set; }

        [DisplayName("Faturamento previsto")]
        public decimal FaturamentoPrevisto { get; set; }

        [DisplayName("Faturamento realizado")]
        public decimal FaturamentoRealizado { get; set; }

        [DisplayName("Número de profissionais")]
        public int NumeroProfissionais { get; set; }

        [DisplayName("Situação")]
        public SituacaoProjeto Situacao { get; set; }

        [DisplayName("Patrimônio:")]
        public decimal TotalPatrimonio { get; set; }

        [DisplayName("Compartilhado:")]
        public decimal TotalCompartilhado { get; set; }

        [DisplayName("Servico:")]
        public decimal TotalServico { get; set; }

        [DisplayName("Saúde")]
        public decimal Saude { get; set; }

        public decimal LimiteSaudeBoa { get; set; }

        public decimal LimiteSaudeRegular { get; set; }

        public decimal LimiteSaudeCritica { get; set; }

        public ProjetoDetalheModel()
        {

        }

        public ProjetoDetalheModel(Projeto projeto, decimal totalPatrimonio, decimal totalCompartilhado, decimal totalServico, decimal saude, ServicoDeConfiguracao configuracao)
        {
            this.Id = projeto.Id;
            this.Nome = projeto.Nome;
            this.Gerente = projeto.Gerente;
            this.Cliente = projeto.Cliente;
            this.Tecnologia = projeto.Tecnologia;
            this.DataInicio = projeto.DataInicio;
            this.DataFinalPrevista = projeto.DataFinalPrevista;
            this.DataFinalRealizada = projeto.DataFinalRealizada;
            this.FaturamentoPrevisto = projeto.FaturamentoPrevisto;
            this.FaturamentoRealizado = projeto.FaturamentoRealizado.GetValueOrDefault();
            this.NumeroProfissionais = projeto.NumeroDeProfissionais;
            this.Situacao = projeto.Situacao;
            this.TotalPatrimonio = totalPatrimonio;
            this.TotalCompartilhado = totalCompartilhado;
            this.TotalServico = totalServico;
            this.Saude = saude;
            this.LimiteSaudeBoa = configuracao.SaudeDoProjetoBoa;
            this.LimiteSaudeRegular = configuracao.SaudeDoProjetoRegular;
            this.LimiteSaudeCritica = configuracao.SaudeDoProjetoCritica;
        }
    }
}