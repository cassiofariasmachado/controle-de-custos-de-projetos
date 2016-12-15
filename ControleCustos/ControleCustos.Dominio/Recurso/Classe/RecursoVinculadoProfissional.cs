using System;

namespace ControleCustos.Dominio.Recurso.Classe
{
    public class RecursoVinculadoProfissional : Recurso
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal ValorCompra { get; set; }
        public int TempoDeVidaUtil { get; set; }
    }
}
