using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleCustos.Models
{
    public class RelatorioModel
    {
        public IList<ProjetoRelatorioModel> Projetos { get; set; }

        public decimal TotalCustosTotais { get; set; }

        public decimal TotalCustosMesCorrente { get; set; }

        public decimal TotalFaturamentoPrevisto { get; set; }

        public RelatorioModel() { }

        public RelatorioModel(IList<ProjetoRelatorioModel> projetos)
        {
            this.Projetos = projetos;
            this.TotalCustosTotais = projetos.Sum(p => p.CustoTotal);
            this.TotalCustosMesCorrente = projetos.Sum(p => p.CustoMesCorrente);
            this.TotalFaturamentoPrevisto = projetos.Sum(p => p.FaturamentoPrevisto);
        }
    }
}