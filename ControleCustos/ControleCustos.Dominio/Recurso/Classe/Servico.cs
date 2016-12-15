using ControleCustos.Dominio.Recurso.Enum;

namespace ControleCustos.Dominio.Recurso.Classe
{
    public class Servico : Recurso
    {
        public string Descricao { get; set; }
        public TipoServico TipoServico { get; set; }
    }
}
