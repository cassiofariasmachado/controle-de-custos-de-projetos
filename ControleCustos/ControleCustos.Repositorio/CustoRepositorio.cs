using ControleCustos.Dominio;
using ControleCustos.Dominio.Interface;
using System;
using System.Linq;

namespace ControleCustos.Repositorio
{
    public class CustoRepositorio : ICustoRepositorio
    {
        public decimal CalcularCustoFixo(UnidadeTecnica unidadeTecnica, DateTime periodo)
        {
            using (var context = new DatabaseContext())
            {
                return context.Custo.Where(u => u.UnidadeTecnica.Id == unidadeTecnica.Id 
                && u.Periodo.Month == periodo.Month 
                && u.Periodo.Year == periodo.Year)
                .Sum(u => u.Valor);
            }
        }

    }
}
