using System;

namespace ControleCustos.Dominio
{
    public class Custo
    {
        public int Id { get; private set; }
        public decimal EnergiaEletrica { get; private set; }
        public decimal Agua { get; private set; }
        public decimal MaterialExpediente { get; private set; }
        public decimal MaterialEscritorio { get; private set; }
        public decimal Condominio { get; private set; }
        public decimal Aluguel { get; private set; }
        public decimal Internet { get; private set; }
        public UnidadeTecnica UnidadeTecnica { get; private set; }
        public DateTime Periodo { get; private set; }

        public Custo(int id, decimal energiaEletrica, decimal agua, decimal materialExpediente, decimal materialEscritorio, decimal condominio, decimal aluguel, decimal internet, UnidadeTecnica UnidadeTecnica, DateTime Periodo)
        {
            this.Id = id;
            this.EnergiaEletrica = energiaEletrica;
            this.Agua = agua;
            this.MaterialExpediente = materialExpediente;
            this.MaterialEscritorio = materialEscritorio;
            this.Condominio = condominio;
            this.Aluguel = aluguel;
            this.Internet = internet;
            this.UnidadeTecnica = UnidadeTecnica;
            this.Periodo = Periodo;
        }
    }
}
