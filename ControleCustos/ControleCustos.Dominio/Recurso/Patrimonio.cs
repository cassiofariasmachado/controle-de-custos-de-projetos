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
    }
}
