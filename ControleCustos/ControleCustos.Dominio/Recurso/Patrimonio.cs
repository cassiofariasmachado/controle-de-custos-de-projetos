using ControleCustos.Dominio.Enum;
using System;
using System.ComponentModel.DataAnnotations;

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
            TipoRecurso tipoRecurso, 
            decimal valorMensal, 
            SituacaoRecurso situacao, 
            string modelo,
            string marca, 
            DateTime dataCompra, 
            decimal valorCompra,
            int tempoVidaUtil)
            : base(id, nome, tipoRecurso, valorMensal, situacao)
        {
            this.Modelo = modelo;
            this.Marca = marca;
            this.DataCompra = dataCompra;
            this.ValorCompra = valorCompra;
            this.TempoDeVidaUtil = tempoVidaUtil;
        }
    }
}
