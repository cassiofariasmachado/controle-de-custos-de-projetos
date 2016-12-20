using System;

namespace ControleCustos.Dominio
{
    public class ControleRecurso
    {
        public int Id { get; set; }

        public Projeto Projeto { get; private set; }

        public Recurso Recurso { get; private set; }

        public DateTime DataInicio { get; private set; }

        public DateTime DataFim { get; private set; }

        public ControleRecurso() { }

        public ControleRecurso(int id, Projeto projeto, Recurso recurso, DateTime dataInicio, DateTime dataFim)
        {
            this.Id = id;
            this.Projeto = projeto;
            this.Recurso = recurso;
            this.DataInicio = dataInicio;
            this.DataFim = dataFim;
        }
    }
}
