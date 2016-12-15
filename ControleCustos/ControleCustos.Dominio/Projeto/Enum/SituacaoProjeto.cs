using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Dominio.Projeto.Enum
{
    public enum SituacaoProjeto
    {
        [Display(Name = "Novo")]
        Novo,

        [Display(Name = "Em andamento")]
        EmAndamento,

        [Display(Name = "Cancelado")]
        Cancelado,

        [Display(Name = "Concluído")]
        Concluido
    }
}
