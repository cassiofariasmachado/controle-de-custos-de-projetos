using ControleCustos.Dominio.Recurso.Enum;

namespace ControleCustos.Dominio.Recurso.Classe
{
    public abstract class Recurso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoRecurso TipoRecurso { get; set; }
        public decimal ValorMensal { get; set; }
        public Situacao Situacao { get; set; }
    }
}
