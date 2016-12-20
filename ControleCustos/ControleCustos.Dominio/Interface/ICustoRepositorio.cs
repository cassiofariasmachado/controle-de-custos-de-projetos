using System;

namespace ControleCustos.Dominio.Interface
{
    public interface ICustoRepositorio
    {
        decimal CalcularCustoFixo(UnidadeTecnica unidadeTecnica, DateTime periodo);
    }
}
