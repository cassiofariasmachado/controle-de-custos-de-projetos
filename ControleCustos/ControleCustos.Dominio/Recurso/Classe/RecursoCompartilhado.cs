using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Dominio.Recurso.Classe
{
    public class RecursoCompartilhado : Recurso
    {
        [Required]
        public string EnderecoIp { get; set; }

        [Required]
        public bool BaseDeDados { get; set; }

        [Required]
        public decimal EspacoEmDisco { get; set; }

        [Required]
        public int Processadores { get; set; }

        [Required]
        public decimal Memoria { get; set; }

        [Required]
        public bool BackupDiario { get; set; }

        [Required]
        public bool BackupIncremental { get; set; }
    }
}
