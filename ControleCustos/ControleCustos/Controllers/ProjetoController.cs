using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;
using ControleCustos.Dominio.Interface;
using ControleCustos.Filtro;
using ControleCustos.Models;
using ControleCustos.Servicos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vereyon.Web;

namespace ControleCustos.Controllers
{
    public class ProjetoController : Controller
    {
        private IProjetoRepositorio projetoRepositorio;
        private UsuarioServico usuarioServico;
        private IRecursoRepositorio recursoRepositorio;
        private const int quantidadeDeRecursosPorPagina = 5;
        private IControleRecursoRepositorio controleRecursoRepositorio;

        public ProjetoController()
        {
            this.projetoRepositorio = ServicoDeDependencias.MontarProjetoRepositorio();
            this.usuarioServico = ServicoDeDependencias.MontarUsuarioServico();
            this.recursoRepositorio = ServicoDeDependencias.MontarRecursoRepositorio();
            this.controleRecursoRepositorio = ServicoDeDependencias.MontarControleRecursoRepositorio();
        }


        [Autorizador(Roles = "Administrador,Gerente")]
        public ActionResult ListaProjetos()
        {
            return View();
        }

        public PartialViewResult ListaProjetosFiltrada()
        {
            IList<Projeto> projetos = new List<Projeto>();

            if (ServicoDeAutenticacao.UsuarioLogado.Permissao == Permissao.Gerente)
            {
                projetos = projetoRepositorio.ListarPorGerente(this.usuarioServico.BuscarPorEmail(ServicoDeAutenticacao.UsuarioLogado.Email));
            }
            else
            {
                projetos = projetoRepositorio.Listar();
            }

            IList<ProjetoModel> model = ConverterEmListagemDeProjetos(projetos);

            return PartialView("_ListaProjetosFiltrada", model); ;
        }
        
        [Autorizador(Roles = "Administrador")]
        public ActionResult Detalhe(int id)
        {
            var projeto = projetoRepositorio.Buscar(id);
            var model = new ProjetoModel(projeto);
            return View(model);
        }

        [Autorizador(Roles = "Gerente")]
        public ActionResult Cadastro()
        {
            return View();
        }

        [Autorizador(Roles = "Gerente")]
        public ActionResult Editar(int id)
        {
            var projeto = projetoRepositorio.Buscar(id);
            if (projeto.Gerente.Email != ServicoDeAutenticacao.UsuarioLogado.Email)
            {
                FlashMessage.Warning("Você não pode editar projetos de outros gerentes.");
                return RedirectToAction("ListaProjetos");
            }
            var model = new ProjetoModel(projeto);
            return View("Cadastro", model);
        }

        [HttpPost]
        [Autorizador(Roles = "Gerente")]
        public ActionResult Salvar(ProjetoModel model)
        {
            if (ModelState.IsValid)
            {
                model.Gerente = this.usuarioServico.BuscarPorEmail(ServicoDeAutenticacao.UsuarioLogado.Email);
                if (model.Id == null)
                {
                    Projeto projeto = ConverterModelParaProjeto(model);
                    this.projetoRepositorio.Inserir(projeto);
                    FlashMessage.Confirmation("Projeto adicionado com sucesso.");
                    return RedirectToAction("ListaProjetos");
                }
                else
                {
                    Projeto projeto = ConverterModelEditadaParaProjeto(model);
                    this.projetoRepositorio.Atualizar(projeto);
                    FlashMessage.Confirmation("Projeto editado com sucesso.");
                    return RedirectToAction("ListaProjetos");
                }

            }
            else
            {
                ModelState.AddModelError("", "Erro de cadastro! Verifique os campos.");
            }
            return View("Cadastro");
        }

        private Projeto ConverterModelParaProjeto(ProjetoModel model)
        {
            return new Projeto(model.Id.GetValueOrDefault(), model.Nome, model.Gerente, model.Cliente, model.Tecnologia, model.DataInicio,
                                    model.DataFinalPrevista, model.FaturamentoPrevisto, model.NumeroProfissionais, model.Situacao);
        }

        private Projeto ConverterModelEditadaParaProjeto(ProjetoModel model)
        {
            return new Projeto(model.Id.GetValueOrDefault(), model.Nome, model.Gerente, model.Cliente, model.Tecnologia, model.DataInicio,
                                    model.DataFinalPrevista, model.DataFinalRealizada.GetValueOrDefault(), model.FaturamentoPrevisto, model.FaturamentoRealizado, model.NumeroProfissionais, model.Situacao);
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

        private IList<ProjetoModel> ConverterEmListagemDeProjetos(IList<Projeto> projetos)
        {
            IList<ProjetoModel> model = new List<ProjetoModel>();

            foreach (var projeto in projetos)
            {
                model.Add(new ProjetoModel(projeto));
            }

            return model;
        }

        public PartialViewResult CarregarModal(int id)
        {
            Recurso recurso = this.recursoRepositorio.Buscar(id);
            ControleRecursoModel model = new ControleRecursoModel(recurso, new Projeto());
            return PartialView("_ModalRecurso", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SalvarModalRecurso(ControleRecursoModel model)
        {

            if (ModelState.IsValid)
            {

            }
            return new JsonResult();
        }

    }
}