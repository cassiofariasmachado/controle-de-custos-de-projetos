using ControleCustos.Dominio;
using ControleCustos.Dominio.Interface;
using ControleCustos.Models;
using ControleCustos.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleCustos.Controllers
{
    public class RecursoController : Controller
    {

        private IRecursoRepositorio recursoRepositorio;
        private IServicoDeConfiguracao servicoDeConfiguracao;

        public RecursoController()
        {
            this.recursoRepositorio = ServicoDeDependencias.MontarRecursoRepositorio();
            this.servicoDeConfiguracao = ServicoDeDependencias.CriarServicoDeConfiguracao();
        }

        public ActionResult Recurso()
        {
            return View();
        }

        public PartialViewResult CarregarListaDeRecursos(int pagina)
        {
            // IList<Recurso> todosOsItens = this.recursoRepositorio.BuscaPaginada(new Compartilhado().GetType(), pagina);
            //RecursoListagemViewModel model = CriarRecursoListagemViewModel(todosOsItens, pagina);

            return null;//PartialView("_ListagemDeRecursos", model);
        }

        private RecursoListagemViewModel CriarRecursoListagemViewModel(IList<Recurso> recursos, int? pagina = null)
        {
            RecursoListagemViewModel model = new RecursoListagemViewModel(recursos);

            if (pagina.HasValue)
            {
                model.PaginaAtual = pagina.Value;
            }

            model.QuantidadeDeRecursosPorPagina = this.servicoDeConfiguracao.QuantidadeDeRecursosPorPagina;
            return model;
        }
    }
}