using ControleCustos.Dominio;
using ControleCustos.Dominio.Interface;
using ControleCustos.Filtro;
using ControleCustos.Models;
using ControleCustos.Servicos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ControleCustos.Controllers
{
    public class ProjetoController : Controller
    {
        private IProjetoRepositorio projetoRepositorio;
        private UsuarioServico usuarioServico;
        private IRecursoRepositorio recursoRepositorio;
        private const int quantidadeDeRecursosPorPagina = 5;

        public ProjetoController()
        {
            this.projetoRepositorio = ServicoDeDependencias.MontarProjetoRepositorio();
            this.usuarioServico = ServicoDeDependencias.MontarUsuarioServico();
            this.recursoRepositorio = ServicoDeDependencias.MontarRecursoRepositorio();
        }

        public ActionResult ListaProjetos()
        {
            return View();
        }

        [Autorizador(Roles = "Gerente")]
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [Autorizador(Roles = "Gerente")]
        public JsonResult Salvar(ProjetoModel model)
        {
            if (ModelState.IsValid)
            {
                model.Gerente = this.usuarioServico.BuscarPorEmail(ServicoDeAutenticacao.UsuarioLogado.Email);
                Projeto projeto = ConverterModelParaProjeto(model);
                if (projeto.Id == 0)
                {
                    this.projetoRepositorio.Inserir(projeto);
                    return Json(new { Mensagem = "Cadastro efetuado com sucesso." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    this.projetoRepositorio.Atualizar(projeto);
                    return Json(new { Mensagem = "Projeto editado com sucesso." }, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                ModelState.AddModelError("", "Erro de cadastro! Verifique os campos.");
            }
            return Json(new { Mensagem = "Erro de cadastro! Verifique os campos." }, JsonRequestBehavior.AllowGet);
        }

        private Projeto ConverterModelParaProjeto(ProjetoModel model)
        {
            return new Projeto(model.Id.GetValueOrDefault(), model.Nome, model.Gerente, model.Cliente, model.Tecnologia, model.DataInicio,
                                    model.DataFinalPrevista, model.FaturamentoPrevisto, model.NumeroProfissionais, model.Situacao);
        }

        private ProjetoModel CriarProjetoViewModel(Projeto projeto)
        {
            var model = new ProjetoModel(projeto);
            return model;
        }

        public ActionResult Recurso()
        {
            return View();
        }

        public PartialViewResult CarregarListaDeRecursosCompartilhados(int pagina)
        {
            IList<Recurso> recursos = this.recursoRepositorio.BuscaPaginadaRecursoCompartilhados(pagina, quantidadeDeRecursosPorPagina);
            RecursoListagemModel model = CriarRecursoListagemViewModel(recursos, pagina);
            return PartialView("_ListagemDeRecursos", model);
        }

        public PartialViewResult CarregarListaDePatrimonios(int pagina)
        {
            IList<Recurso> recursos = this.recursoRepositorio.BuscaPaginadaPatrimonios(pagina, quantidadeDeRecursosPorPagina);
            RecursoListagemModel model = CriarRecursoListagemViewModel(recursos, pagina);
            return PartialView("_ListagemDeRecursos", model);
        }

        public PartialViewResult CarregarListaDeServicos(int pagina)
        {
            IList<Recurso> recursos = this.recursoRepositorio.BuscaPaginadaServicos(pagina, quantidadeDeRecursosPorPagina);
            RecursoListagemModel model = CriarRecursoListagemViewModel(recursos, pagina);
            return PartialView("_ListagemDeRecursos", model);
        }

        private RecursoListagemModel CriarRecursoListagemViewModel(IList<Recurso> recursos, int pagina)
        {
            RecursoListagemModel model = new RecursoListagemModel(recursos);

            model.PaginaAtual = pagina;

            model.QuantidadeDeRecursosPorPagina = quantidadeDeRecursosPorPagina;
            return model;
        }

    }
}