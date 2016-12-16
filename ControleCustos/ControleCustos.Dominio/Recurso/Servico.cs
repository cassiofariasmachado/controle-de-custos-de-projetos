using ControleCustos.Dominio.Enum;

namespace ControleCustos.Dominio
{
    public class Servico : Recurso
    {
        public string Descricao { get; private set; }

        public TipoServico TipoServico { get; private set; }
    }
}
