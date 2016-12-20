using System;

namespace ControleCustos.Dominio.Interface
{
    public interface IColaboradoresRepositorio
    {
        Colaboradores BuscarPelaUnidadeTecnicaEMes(UnidadeTecnica unidadeTecnica, DateTime mes);
    }
}
