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
        [StringLength(20, MinimumLength = 1, ErrorMessage = "O nome deve possuir até 30 caracteres")]
        public string Nome { get; set; }

        public Usuario Gerente { get; set; }

        [Required]
        [DisplayName("Cliente")]
        public string Cliente { get; set; }

        [Required]
        [DisplayName("Principal tecnologia")]
        public string Tecnologia { get; set; }

        [Required]
        [DisplayName("Data de início")]
        public DateTime DataInicio { get; set; }

        [Required]
        [DisplayName("Data final prevista")]
        public DateTime DataFinalPrevista { get; set; }

        [DisplayName("Data final realizada")]
        public DateTime? DataFinalRealizada { get; set; }

        [Required]
        [DisplayName("Faturamento previsto")]
        public decimal FaturamentoPrevisto { get; set; }

        [Required]
        [DisplayName("Número de profissionais")]
        public int NumeroProfissionais { get; set; }

        [Required]
        [DisplayName("Situação")]
        public SituacaoProjeto Situacao { get; set; }

        public ProjetoModel()
        {

        }

        public ProjetoModel(Projeto projeto)
        {
            this.Id = 0;
            this.Nome = projeto.Nome;
            this.Gerente = projeto.Gerente;
            this.Cliente = projeto.Cliente;
            this.Tecnologia = projeto.Tecnologia;
            this.DataInicio = projeto.DataInicio;
            this.DataFinalPrevista = projeto.DataFinalPrevista;
            this.DataFinalRealizada = projeto.DataFinalRealizada;
            this.FaturamentoPrevisto = projeto.FaturamentoPrevisto;
            this.NumeroProfissionais = projeto.NumeroDeProfissionais;
            this.Situacao = projeto.Situacao;
        }
    }
}