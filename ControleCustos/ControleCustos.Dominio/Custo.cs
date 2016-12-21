using System;

namespace ControleCustos.Dominio
{
    public class Custo
    {
        public int Id { get; private set; }
        public string Conta { get; private set; }
        public decimal Valor { get; private set; }
        public UnidadeTecnica UnidadeTecnica { get; private set; }
        public DateTime Periodo { get; private set; }
        public Custo()
        {

        }
        public Custo(int id, string conta, decimal valor, UnidadeTecnica UnidadeTecnica, DateTime Periodo)
        {
            this.Id = id;
            this.Conta = conta;
            this.Valor = valor;
            this.UnidadeTecnica = UnidadeTecnica;
            this.Periodo = Periodo;
        }
    }
}
