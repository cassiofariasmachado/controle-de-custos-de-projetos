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
        public string EspacoEmDisco { get; set; }

        [Required]
        public string Processadores { get; set; }

        [Required]
        public string Memoria { get; set; }

        [Required]
        public bool BackupDiario { get; set; }

        [Required]
        public bool BackupIncremental { get; set; }
    }
}
