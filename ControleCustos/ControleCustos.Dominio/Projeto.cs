using ControleCustos.Dominio.Enum;
using System;

namespace ControleCustos.Dominio
{
    public class Projeto
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public Usuario Gerente { get; private set; }

        public string Cliente { get; private set; }

        public string Tecnologia { get; private set; }

        public DateTime DataInicio { get; private set; }

        public DateTime DataFinalPrevista { get; private set; }

        public DateTime? DataFinalRealizada { get; private set; }

        public decimal FaturamentoPrevisto { get; private set; }

        public decimal? FaturamentoRealizado { get; private set; }

        public int NumeroDeProfissionais { get; private set; }

        public SituacaoProjeto Situacao { get; private set; }

        public Projeto() { }

        public Projeto(int id,
                       string nome,
                       Usuario gerente,
                       string cliente,
                       string tecnologia,
                       DateTime dataInicio,
                       DateTime dataFinalPrevista,
                       decimal faturamentoPrevisto,
                       int numeroProfissionais,
                       SituacaoProjeto situacao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Gerente = gerente;
            this.Cliente = cliente;
            this.Tecnologia = tecnologia;
            this.DataInicio = dataInicio;
            this.DataFinalPrevista = dataFinalPrevista;
            this.FaturamentoPrevisto = faturamentoPrevisto;
            this.NumeroDeProfissionais = numeroProfissionais;
            this.Situacao = situacao;
        }

        public Projeto(int id,
                       string nome,
                       Usuario gerente,
                       string cliente,
                       string tecnologia,
                       DateTime dataInicio,
                       DateTime dataFinalPrevista,
                       DateTime? dataFinalRealizada,
                       decimal faturamentoPrevisto,
                       decimal? faturamentoRealizado,
                       int numeroProfissionais,
                       SituacaoProjeto situacao)
            : this(id, nome, gerente, cliente, tecnologia, dataInicio, dataFinalPrevista, faturamentoPrevisto, numeroProfissionais, situacao)
        {
            this.DataFinalRealizada = dataFinalRealizada;
            this.FaturamentoRealizado = faturamentoRealizado;
        }
    }
}
