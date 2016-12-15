using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Dominio.Enum
{
    public enum SituacaoRecurso
    {
        [Display(Name = "Disponível")]
        Disponivel,

        [Display(Name = "Indisponível")]
        Indisponivel
    }
}
