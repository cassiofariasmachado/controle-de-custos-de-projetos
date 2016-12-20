using System;

namespace ControleCustos.Dominio
{
    public class Colaboradores
    {
        public int Id { get; private set; }
        public int QuantidadeDeColaboradores { get; private set; }
        public DateTime Periodo { get; private set; }
        public UnidadeTecnica UnidadeTecnica { get; private set; }
        public Colaboradores()
        {

        }
        public Colaboradores(int id, int quantidadeDeColaboradores, DateTime periodo, UnidadeTecnica unidadeTecnica)
        {
            this.Id = id;
            this.QuantidadeDeColaboradores = quantidadeDeColaboradores;
            this.Periodo = periodo;
            this.UnidadeTecnica = unidadeTecnica;
        }
    }
}
