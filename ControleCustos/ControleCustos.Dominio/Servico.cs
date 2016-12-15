using ControleCustos.Dominio.Enum;
using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Dominio
{
    public class Servico : Recurso
    {
        [Required]
        public string Descricao { get; set; }

        [Required]
        public TipoServico TipoServico { get; set; }
    }
}
