using ControleCustos.Dominio.Enum;
using System;

namespace ControleCustos.Dominio
{
    public class Patrimonio : Recurso
    {
        public string Modelo { get; private set; }

        public string Marca { get; private set; }

        public DateTime DataCompra { get; private set; }

        public decimal ValorCompra { get; private set; }

        public int TempoDeVidaUtil { get; private set; }

        public Patrimonio() { }

        public Patrimonio(int id, 
            string nome,  
            decimal valorMensal, 
            SituacaoRecurso situacao,
            bool interno,
            string modelo,
            string marca, 
            DateTime dataCompra, 
            decimal valorCompra,
            int tempoVidaUtil)
            : base(id, nome, valorMensal, situacao, interno)
        {
            this.Modelo = modelo;
            this.Marca = marca;
            this.DataCompra = dataCompra;
            this.ValorCompra = valorCompra;
            this.TempoDeVidaUtil = tempoVidaUtil;
        }
    }
}
