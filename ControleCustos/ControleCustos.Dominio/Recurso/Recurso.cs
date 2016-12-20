using ControleCustos.Dominio.Enum;

namespace ControleCustos.Dominio
{
    public abstract class Recurso
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public TipoRecurso TipoRecurso { get; private set; }

        public decimal ValorMensal { get; private set; }

        public SituacaoRecurso Situacao { get; private set; }

        public bool Interno { get; private set; }

        public Recurso() { }

        public Recurso(int id, string nome, TipoRecurso tipoRecurso, decimal valorMensal, SituacaoRecurso situacao, bool interno)
        {
            this.Id = id;
            this.Nome = nome;
            this.TipoRecurso = tipoRecurso;
            this.ValorMensal = valorMensal;
            this.Situacao = situacao;
            this.Interno = interno;
        }
    }
}
