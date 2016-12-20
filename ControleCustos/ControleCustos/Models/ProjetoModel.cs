using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Models
{
    public class ProjetoModel
    {

        public int? Id { get; set; }

        [Required]
        [DisplayName("Nome do projeto")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O nome deve possuir entre 5 e 50 caracteres")]
        public string Nome { get; set; }

        public Usuario Gerente { get; set; }

        [Required]
        [DisplayName("Cliente")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome do cliente deve possuir entre 3 e 50 caracteres")]
        public string Cliente { get; set; }

        [Required]
        [DisplayName("Principal tecnologia")]
        [StringLength(50, ErrorMessage = "A tecnologia deve possuir menos de 50 caracteres")]
        public string Tecnologia { get; set; }

        [Required]
        [DisplayName("Data de início")]
        [DataType(DataType.Date, ErrorMessage = "A data deve ser no formato dd/mm/aaaa")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; }

        [Required]
        [DisplayName("Data final prevista")]
        [DataType(DataType.Date, ErrorMessage = "A data deve ser no formato dd/mm/aaaa")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFinalPrevista { get; set; }

        [DisplayName("Data final realizada")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataFinalRealizada { get; set; }

        [Required]
        [DisplayName("Faturamento previsto")]
        public decimal FaturamentoPrevisto { get; set; }

        [DisplayName("Faturamento realizado")]
        public decimal FaturamentoRealizado { get; set; }

        [Required]
        [DisplayName("Número de profissionais")]
        [Range(1, int.MaxValue, ErrorMessage = "Número de profissionais deve ser maior do que zero")]
        public int NumeroProfissionais { get; set; }

        [Required]
        [DisplayName("Situação")]
        public SituacaoProjeto Situacao { get; set; }

        public ProjetoModel()
        {

        }

        public ProjetoModel(Projeto projeto)
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
        }
    }
}