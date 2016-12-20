using System;
using ControleCustos.Dominio;
using ControleCustos.Dominio.Interface;
using System.Linq;

namespace ControleCustos.Repositorio
{
    public class ColaboradoresRepositorio : IColaboradoresRepositorio
    {
        public Colaboradores BuscarPelaUnidadeTecnicaEMes(UnidadeTecnica unidadeTecnica, DateTime mes)
        {
            using (var context = new DatabaseContext())
            {
                return context.Colaboradores.Where(
                    c => c.UnidadeTecnica.Id == unidadeTecnica.Id
                && c.Periodo.Month == mes.Month
                && c.Periodo.Year == mes.Year
                ).FirstOrDefault();
            }
        }
    }
}
