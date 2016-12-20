using System;

namespace ControleCustos.Dominio.Interface
{
    public interface IColaboradoresRepositorio
    {
        Colaboradores BuscarPelaUnidadeTecnicaEPeriodo(UnidadeTecnica unidadeTecnica, DateTime periodo);
    }
}
