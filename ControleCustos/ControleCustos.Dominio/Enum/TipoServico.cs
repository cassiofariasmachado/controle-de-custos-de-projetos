using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Dominio.Enum
{
    public enum TipoServico
    {
        [Display(Name = "Serviço")]
        Servico,

        [Display(Name = "Licença")]
        Licenca 
    }
}
