using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;
using ControleCustos.Dominio.Interface;
using ControleCustos.Filtro;
using ControleCustos.Models;
using ControleCustos.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleCustos.Controllers
{
    [Autorizador(Roles = "Administrador")]
    public class RelatorioController : Controller
    {
        IProjetoRepositorio projetoRepositorio = ServicoDeDependencias.MontarProjetoRepositorio();
        CalculoServico calculoServico = ServicoDeDependencias.MontarCalculoServico();

        public ActionResult Index()
        {
            IList<Projeto> projetos = projetoRepositorio.ListarProjetosEmAndamento();
            IList<ProjetoParaRelatorioModel> projetosRelatorio = new List<ProjetoParaRelatorioModel>();
            foreach(var projeto in projetos)
            {
                projetosRelatorio.Add(new ProjetoParaRelatorioModel(projeto, calculoServico));
            }
            RelatorioModel model = new RelatorioModel(projetosRelatorio);
            return View(model);
        }

        public JsonResult GerarGraficoMenorCusto()
        {
            IList<Projeto> projetos = projetoRepositorio.ListarProjetosEmAndamento();
            IList<List<dynamic>> dados = new List<List<dynamic>>();

            foreach (var projeto in projetos)
            {
                dados.Add(new List<dynamic> {
                    projeto.Nome,
                    calculoServico.CalcularCustoPercentual(projeto, DateTime.Now)
                });
            }

            return Json(new { Dados = dados }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GerarGraficoMaiorCusto()
        {
            IList<Projeto> projetos = projetoRepositorio.ListarProjetosEncerrados();
            IList<List<dynamic>> dados = new List<List<dynamic>>();

            foreach (var projeto in projetos)
            {
                dados.Add(new List<dynamic> {
                    projeto.Nome,
                    calculoServico.CalcularCustoTotalAte(projeto, projeto.DataFinalRealizada.Value),
                    projeto.FaturamentoRealizado.Value
                });
            }

            return Json(new { Dados = dados }, JsonRequestBehavior.AllowGet);
        }
    }
}