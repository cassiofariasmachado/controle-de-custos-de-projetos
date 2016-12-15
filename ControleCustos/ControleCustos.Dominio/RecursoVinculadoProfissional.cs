using System;
using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Dominio
{
    public class RecursoVinculadoProfissional : Recurso
    {
        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public DateTime DataCompra { get; set; }

        [Required]
        public decimal ValorCompra { get; set; }

        [Required]
        public int TempoDeVidaUtil { get; set; }
    }
}
