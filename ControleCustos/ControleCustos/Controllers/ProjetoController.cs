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
        private CalculoServico calculoServico;

        public ProjetoController()
        {
            this.projetoRepositorio = ServicoDeDependencias.MontarProjetoRepositorio();
            this.usuarioServico = ServicoDeDependencias.MontarUsuarioServico();
            this.recursoRepositorio = ServicoDeDependencias.MontarRecursoRepositorio();
            this.controleRecursoRepositorio = ServicoDeDependencias.MontarControleRecursoRepositorio();
            this.calculoServico = ServicoDeDependencias.MontarCalculoServico();
        }


        [Autorizador(Roles = "Administrador,Gerente")]
        public ActionResult ListaProjetos()
        {
            return View();
        }

        public PartialViewResult ListaProjetosFiltrada(string filtro = "")
        {
            IList<Projeto> projetos = new List<Projeto>();

            if (ServicoDeAutenticacao.UsuarioLogado.Permissao == Permissao.Gerente)
            {
                projetos = projetoRepositorio.ListarPorGerente(this.usuarioServico.BuscarPorEmail(ServicoDeAutenticacao.UsuarioLogado.Email), filtro);
            }
            else
            {
                projetos = projetoRepositorio.Listar(filtro);
            }

            IList<ProjetoModel> model = ConverterEmListagemDeProjetos(projetos);

            return PartialView("_ListaProjetosFiltrada", model); ;
        }

        [Autorizador(Roles = "Administrador,Gerente")]
        public ActionResult Detalhe(int id)
        {
            var projeto = projetoRepositorio.Buscar(id);
            if (ServicoDeAutenticacao.UsuarioLogado.Permissao != Permissao.Administrador && projeto.Gerente.Email != ServicoDeAutenticacao.UsuarioLogado.Email)
            {
                FlashMessage.Danger("Você não pode visualizar projetos de outros gerentes.");
                return RedirectToAction("ListaProjetos");
            }
            decimal totalPatrimonio = this.calculoServico.CalcularCustoPatrimonioTotalAte(projeto, DateTime.Now);
            decimal totalCompartilhado = this.calculoServico.CalcularCustoCompartilhadoTotalAte(projeto, DateTime.Now);
            decimal totalServico = this.calculoServico.CalcularCustoServicoTotalAte(projeto, DateTime.Now);
            var model = new ProjetoDetalheModel(projeto, totalPatrimonio, totalCompartilhado, totalServico);
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
                FlashMessage.Danger("Você não pode editar projetos de outros gerentes.");
                return RedirectToAction("ListaProjetos");
            }
            var model = new ProjetoModel(projeto);
            return View("Cadastro", model);
        }

        [HttpPost]
        [Autorizador(Roles = "Gerente")]
        [ValidateAntiForgeryToken]
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

        [HttpGet]
        [Autorizador(Roles = "Gerente")]
        public PartialViewResult CarregarListaDeRecursosCompartilhados(int pagina, Projeto projeto = null)
        {
            IList<Recurso> recursos = this.recursoRepositorio.BuscaPaginadaRecursoCompartilhados(pagina, quantidadeDeRecursosPorPagina);
            RecursoListagemModel model = CriarRecursoListagemViewModel(recursos, pagina, this.recursoRepositorio.CompartilhadoCount());
            return PartialView("_ListagemDeRecursos", model);
        }

        [HttpGet]
        [Autorizador(Roles = "Gerente")]
        public PartialViewResult CarregarListaDePatrimonios(int pagina)
        {
            IList<Recurso> recursos = this.recursoRepositorio.BuscaPaginadaPatrimonios(pagina, quantidadeDeRecursosPorPagina);
            RecursoListagemModel model = CriarRecursoListagemViewModel(recursos, pagina, this.recursoRepositorio.PatrimonioCount());
            return PartialView("_ListagemDeRecursos", model);
        }

        [HttpGet]
        [Autorizador(Roles = "Gerente")]
        public PartialViewResult CarregarListaDeServicos(int pagina)
        {
            IList<Recurso> recursos = this.recursoRepositorio.BuscaPaginadaServicos(pagina, quantidadeDeRecursosPorPagina);
            RecursoListagemModel model = CriarRecursoListagemViewModel(recursos, pagina, this.recursoRepositorio.ServicoCount());
            return PartialView("_ListagemDeRecursos", model);
        }

        [HttpGet]
        [Autorizador(Roles = "Gerente")]
        public ActionResult Recurso(int idProjeto)
        {
            Projeto projeto = this.projetoRepositorio.Buscar(idProjeto);
            if (projeto.Gerente.Email != ServicoDeAutenticacao.UsuarioLogado.Email)
            {
                FlashMessage.Warning("Você não pode editar projetos de outros gerentes.");
                return RedirectToAction("ListaProjetos");
            }
            ProjetoModel model = new ProjetoModel(projeto);
            return View(model);
        }

        [HttpGet]
        [Autorizador(Roles = "Gerente")]
        public PartialViewResult CarregarModal(int idRecurso, int idProjeto)
        {
            Projeto projeto = this.projetoRepositorio.Buscar(idProjeto);
            if (projeto.Gerente.Email != ServicoDeAutenticacao.UsuarioLogado.Email)
            {
                FlashMessage.Warning("Você não pode adicionar recursos a projetos de outros gerentes.");
                return PartialView("_ModalRecurso", new ControleRecursoModel());
            }
            Recurso recurso = this.recursoRepositorio.Buscar(idRecurso);
            ControleRecursoModel model = new ControleRecursoModel(recurso, projeto, projeto.DataInicio, projeto.DataFinalPrevista);
            return PartialView("_ModalRecurso", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Autorizador(Roles = "Gerente")]
        public JsonResult SalvarModalRecurso(ControleRecursoModel model)
        {
            Projeto projeto = this.projetoRepositorio.Buscar(model.IdProjeto);

            if (projeto.Gerente.Email != ServicoDeAutenticacao.UsuarioLogado.Email)
                return Json("Você não pode adicionar recursos a projetos de outros gerentes!", JsonRequestBehavior.AllowGet);
            if (!this.EhDataValida(projeto, model))
                return Json("Erro data inválida!", JsonRequestBehavior.AllowGet);

            if (ModelState.IsValid)
            {
                ControleRecurso controleRecurso = this.ConverterModelParaControleRecurso(model);
                controleRecursoRepositorio.Inserir(controleRecurso);
                return Json("Adicionado Com Sucesso.", JsonRequestBehavior.AllowGet);
            }
            return Json("Erro ao salvar.", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Autorizador(Roles = "Gerente,Administrador")]
        public PartialViewResult CarregarListaDeRecursosDoProjeto(int idProjeto)
        {
            Projeto projeto = this.projetoRepositorio.Buscar(idProjeto);
            if (projeto.Gerente.Email != ServicoDeAutenticacao.UsuarioLogado.Email)
            {
                FlashMessage.Warning("Você não pode ver recursos de projetos de outros gerentes.");
                return PartialView("_ListaDeRecursosProjeto", null);
            }
            IList<ControleRecurso> controleRecurso = this.controleRecursoRepositorio.Listar(projeto);
            IList<ControleRecursoModel> model = this.ConverterIListControleRecursoParaModel(controleRecurso);
            return PartialView("_ListaDeRecursosProjeto", model);
        }

        [HttpGet]
        [Autorizador(Roles = "Gerente,Administrador")]
        public PartialViewResult CarregarListaDePatrimoniosDoProjeto(int idProjeto)
        {
            Projeto projeto = this.projetoRepositorio.Buscar(idProjeto);
            if (projeto.Gerente.Email != ServicoDeAutenticacao.UsuarioLogado.Email)
            {
                FlashMessage.Warning("Você não pode ver recursos de projetos de outros gerentes.");
                return PartialView("_ListaDeRecursosProjeto", null);
            }
            IList<ControleRecurso> controleRecurso = this.controleRecursoRepositorio.ListarPatrimonio(projeto);
            IList<ControleRecursoModel> model = this.ConverterIListControleRecursoParaModel(controleRecurso);
            return PartialView("_ListaDeRecursosProjeto", model);
        }

        [HttpGet]
        [Autorizador(Roles = "Gerente,Administrador")]
        public PartialViewResult CarregarListaDeCompartilhadosDoProjeto(int idProjeto)
        {
            Projeto projeto = this.projetoRepositorio.Buscar(idProjeto);
            if (projeto.Gerente.Email != ServicoDeAutenticacao.UsuarioLogado.Email)
            {
                FlashMessage.Warning("Você não pode ver recursos de projetos de outros gerentes.");
                return PartialView("_ListaDeRecursosProjeto", null);
            }
            IList<ControleRecurso> controleRecurso = this.controleRecursoRepositorio.ListarCompartilhado(projeto);
            IList<ControleRecursoModel> model = this.ConverterIListControleRecursoParaModel(controleRecurso);
            return PartialView("_ListaDeRecursosProjeto", model);
        }

        [HttpGet]
        [Autorizador(Roles = "Gerente,Administrador")]
        public PartialViewResult CarregarListaDeServicosDoProjeto(int idProjeto)
        {
            Projeto projeto = this.projetoRepositorio.Buscar(idProjeto);
            if (projeto.Gerente.Email != ServicoDeAutenticacao.UsuarioLogado.Email)
            {
                FlashMessage.Warning("Você não pode ver recursos de projetos de outros gerentes.");
                return PartialView("_ListaDeRecursosProjeto", null);
            }
            IList<ControleRecurso> controleRecurso = this.controleRecursoRepositorio.ListarServico(projeto);
            IList<ControleRecursoModel> model = this.ConverterIListControleRecursoParaModel(controleRecurso);
            return PartialView("_ListaDeRecursosProjeto", model);
        }

        private ControleRecurso ConverterModelParaControleRecurso(ControleRecursoModel model)
        {
            return new ControleRecurso(0, this.projetoRepositorio.Buscar(model.IdProjeto), this.recursoRepositorio.Buscar(model.IdRecurso), model.DataInicio, model.DataFim);
        }
        private IList<ControleRecursoModel> ConverterIListControleRecursoParaModel(IList<ControleRecurso> lista)
        {
            IList<ControleRecursoModel> model = new List<ControleRecursoModel>();
            foreach (ControleRecurso controleRecurso in lista)
            {
                model.Add(new ControleRecursoModel(controleRecurso.Recurso, controleRecurso.Projeto, controleRecurso.DataInicio, controleRecurso.DataFim));
            }
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

        private RecursoListagemModel CriarRecursoListagemViewModel(IList<Recurso> recursos, int pagina, int quantidadeTotalRecursos)
        {
            RecursoListagemModel model = new RecursoListagemModel(recursos, quantidadeTotalRecursos);

            model.PaginaAtual = pagina;

            model.QuantidadeDeRecursosPorPagina = quantidadeDeRecursosPorPagina;
            return model;
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

        private bool EhDataValida(Projeto projeto, ControleRecursoModel model)
        {
            if (DateTime.Compare(model.DataInicio, projeto.DataInicio) < 0)
                return false;
            if (DateTime.Compare(model.DataFim, projeto.DataFinalPrevista) > 0)
                return false;
            if (DateTime.Compare(model.DataInicio, model.DataFim) > 0)
                return false;
            return true;
        }
    }
}