using ControleCustos.Dominio.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Dominio
{
    public class Projeto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public Usuario Gerente { get; set; }

        [Required]
        public string Cliente { get; set; }

        [Required]
        public string Tecnologia { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFinalPrevista { get; set; }

        public DateTime? DataFinalRealizada { get; set; }

        [Required]
        public decimal FaturamentoPrevisto { get; set; }

        public decimal FaturamentoRealizado { get; set; }

        [Required]
        public int NumeroDeProfissionais { get; set; }

        [Required]
        public SituacaoProjeto Situacao { get; set; }

        public Projeto() { }

        public Projeto(int id, string nome, string cliente, string tecnologia, DateTime dataInicio,
                                    DateTime dataFinalPrevista, DateTime dataFinalRealizada, decimal faturamentoPrevisto, int numeroProfissionais, SituacaoProjeto situacao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cliente = cliente;
            this.Tecnologia = tecnologia;
            this.DataInicio = dataInicio;
            this.DataFinalPrevista = dataFinalPrevista;
            this.DataFinalRealizada = dataFinalRealizada;
            this.FaturamentoPrevisto = faturamentoPrevisto;
            this.NumeroDeProfissionais = numeroProfissionais;
            this.Situacao = situacao;
        }
    }
}
