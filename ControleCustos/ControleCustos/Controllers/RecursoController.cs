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

        private RecursoServico recursoServico;
        private IServicoDeConfiguracao servicoDeConfiguracao;

        public RecursoController()
        {
            this.recursoServico = ServicoDeDependencias.MontarRecursoServico();
            this.servicoDeConfiguracao = ServicoDeDependencias.CriarServicoDeConfiguracao();
        }

        public ActionResult Recurso()
        {
            return View();
        }

        public PartialViewResult CarregarListaDeRecursos(int pagina)
        {
            IList<Recurso> todosOsItens = this.recursoServico.BuscaPaginada(new RecursoCompartilhado().GetType(), pagina);
            RecursoListagemViewModel model = CriarRecursoListagemViewModel(todosOsItens, pagina);

            return PartialView("_ListagemDeRecursos", model);
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