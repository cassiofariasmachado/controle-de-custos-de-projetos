using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleCustos.Models
{
    public class ProjetoParaRelatorioModel
    {
        public string Cliente { get; set; }

        public string Projeto { get; set; }

        public string Gerente { get; set; }

        public decimal CustoTotal { get; set; }

        public decimal CustoMesCorrente { get; set; }

        public decimal FaturamentoPrevisto { get; set; }

        public SituacaoProjeto Situacao { get; set; }

        public ProjetoParaRelatorioModel() { }

        public ProjetoParaRelatorioModel(Projeto projeto, CalculoServico calculo)
        {
            this.Cliente = projeto.Cliente;
            this.Projeto = projeto.Nome;
            this.Gerente = projeto.Gerente.Nome;
            this.Situacao = projeto.Situacao;
            this.CustoTotal = calculo.CalcularCustoTotalAte(projeto, DateTime.Now);
            this.CustoMesCorrente = calculo.CalcularCustoMensal(projeto, DateTime.Now.Month, DateTime.Now.Year);
            this.FaturamentoPrevisto = projeto.FaturamentoPrevisto;
        }
    }
}