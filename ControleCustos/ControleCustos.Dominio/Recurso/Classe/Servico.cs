using ControleCustos.Dominio.Recurso.Enum;
using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Dominio.Recurso.Classe
{
    public class Servico : Recurso
    {
        [Required]
        public string Descricao { get; set; }

        [Required]
        public TipoServico TipoServico { get; set; }
    }
}
