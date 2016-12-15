using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Dominio.Enum
{
    public enum TipoRecurso
    {
        [Display(Name = "Físico")]
        Fisico,

        [Display(Name = "Lógico")]
        Logico
    }
}