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
    }
}
