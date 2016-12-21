using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;
using ControleCustos.Dominio.Interface;
using ControleCustos.Filtro;
using ControleCustos.Infraestrutura;
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
        private ServicoDeConfiguracao servicoConfiguracao;

        public ProjetoController()
        {
            this.projetoRepositorio = ServicoDeDependencias.MontarProjetoRepositorio();
            this.usuarioServico = ServicoDeDependencias.MontarUsuarioServico();
            this.recursoRepositorio = ServicoDeDependencias.MontarRecursoRepositorio();
            this.controleRecursoRepositorio = ServicoDeDependencias.MontarControleRecursoRepositorio();
            this.calculoServico = ServicoDeDependencias.MontarCalculoServico();
            this.servicoConfiguracao = ServicoDeDependencias.MontarServicoConfiguracao();
        }

        public ProjetoController(IProjetoRepositorio projetoRepositorio, UsuarioServico usuarioServico, IRecursoRepositorio recursoRepositorio, IControleRecursoRepositorio controleRecursoRepositorio, CalculoServico calculoServico)
        {
            this.projetoRepositorio = projetoRepositorio;
            this.usuarioServico = usuarioServico;
            this.recursoRepositorio = recursoRepositorio;
            this.controleRecursoRepositorio = controleRecursoRepositorio;
            this.calculoServico = calculoServico;
        }


        [Autorizador(Roles = "Administrador,Gerente")]
        public ActionResult ListaProjetos()
        {
            return View();
        }

        [Autorizador(Roles = "Gerente")]
        public ActionResult Cadastro()
        {
            return View();
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
            decimal saude = this.calculoServico.CalcularCustoPercentual(projeto, DateTime.Now);
            var model = new ProjetoDetalheModel(projeto, totalPatrimonio, totalCompartilhado, totalServico, saude, servicoConfiguracao);
            return View(model);
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
                if (DateTime.Compare(model.DataInicio, model.DataFinalPrevista) > 0)
                {
                    FlashMessage.Danger("Data início maior que data prevista.");
                    return View("Cadastro", model);
                }
                model.Gerente = this.usuarioServico.BuscarPorEmail(ServicoDeAutenticacao.UsuarioLogado.Email);
                if (model.Id == null)
                {
                    Projeto projeto = model.ConverterModelParaProjeto();
                    this.projetoRepositorio.Inserir(projeto);
                    FlashMessage.Confirmation("Projeto adicionado com sucesso.");
                    return RedirectToAction("ListaProjetos");
                }
                else
                {
                    Projeto projeto = model.ConverterModelEditadaParaProjeto();
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
        [Autorizador(Roles = "Gerente")]
        public PartialViewResult CarregarListaDeRecursosCompartilhados(int pagina, Projeto projeto = null)
        {
            IList<Compartilhado> recursos = this.recursoRepositorio.BuscaPaginadaRecursoCompartilhados(pagina, quantidadeDeRecursosPorPagina);
            CompartilhadoListagemModel model = new CompartilhadoListagemModel(recursos, pagina, quantidadeDeRecursosPorPagina, this.recursoRepositorio.CompartilhadoCount());
            return PartialView("_ListagemCompartilhado", model);
        }

        [HttpGet]
        [Autorizador(Roles = "Gerente")]
        public PartialViewResult CarregarListaDePatrimonios(int pagina)
        {
            IList<Patrimonio> patrimonios = this.recursoRepositorio.BuscaPaginadaPatrimonios(pagina, quantidadeDeRecursosPorPagina);
            PatrimonioListagemModel model = new PatrimonioListagemModel(patrimonios, pagina, quantidadeDeRecursosPorPagina, this.recursoRepositorio.PatrimonioCount());
            return PartialView("_ListagemPatrimonio", model);
        }

        [HttpGet]
        [Autorizador(Roles = "Gerente")]
        public PartialViewResult CarregarListaDeServicos(int pagina)
        {
            IList<Servico> servicos = this.recursoRepositorio.BuscaPaginadaServicos(pagina, quantidadeDeRecursosPorPagina);
            ServicoListagemModel model = new ServicoListagemModel(servicos, pagina, quantidadeDeRecursosPorPagina, this.recursoRepositorio.ServicoCount());
            return PartialView("_ListagemServico", model);
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

        [HttpGet]
        [Autorizador(Roles = "Gerente,Administrador")]
        public PartialViewResult CarregarListaDeRecursosDoProjeto(int idProjeto)
        {
            Projeto projeto = this.projetoRepositorio.Buscar(idProjeto);
            if (ServicoDeAutenticacao.UsuarioLogado.Permissao != Permissao.Administrador && projeto.Gerente.Email != ServicoDeAutenticacao.UsuarioLogado.Email)
            {
                FlashMessage.Warning("Você não pode ver recursos de projetos de outros gerentes.");
                return PartialView("_ListaDeRecursosProjeto", null);
            }
            IList<ControleRecurso> controleRecurso = this.controleRecursoRepositorio.Listar(projeto);
            ControleRecursoListagemModel model = this.ConverterIListControleRecursoParaModel(projeto, controleRecurso);
            return PartialView("_ListaDeRecursosProjeto", model);
        }

        [HttpGet]
        [Autorizador(Roles = "Gerente,Administrador")]
        public PartialViewResult CarregarListaDePatrimoniosDoProjeto(int idProjeto)
        {
            Projeto projeto = this.projetoRepositorio.Buscar(idProjeto);
            if (ServicoDeAutenticacao.UsuarioLogado.Permissao != Permissao.Administrador && projeto.Gerente.Email != ServicoDeAutenticacao.UsuarioLogado.Email)
            {
                FlashMessage.Warning("Você não pode ver recursos de projetos de outros gerentes.");
                return PartialView("_ListaDeRecursosProjeto", null);
            }
            IList<ControleRecurso> controleRecurso = this.controleRecursoRepositorio.ListarPatrimonio(projeto);
            ControleRecursoListagemModel model = this.ConverterIListControleRecursoParaModel(projeto, controleRecurso);
            return PartialView("_ListaDeRecursosProjeto", model);
        }

        [HttpGet]
        [Autorizador(Roles = "Gerente,Administrador")]
        public PartialViewResult CarregarListaDeCompartilhadosDoProjeto(int idProjeto)
        {
            Projeto projeto = this.projetoRepositorio.Buscar(idProjeto);
            if (ServicoDeAutenticacao.UsuarioLogado.Permissao != Permissao.Administrador && projeto.Gerente.Email != ServicoDeAutenticacao.UsuarioLogado.Email)
            {
                FlashMessage.Warning("Você não pode ver recursos de projetos de outros gerentes.");
                return PartialView("_ListaDeRecursosProjeto", null);
            }
            IList<ControleRecurso> controleRecurso = this.controleRecursoRepositorio.ListarCompartilhado(projeto);
            ControleRecursoListagemModel model = this.ConverterIListControleRecursoParaModel(projeto, controleRecurso);
            return PartialView("_ListaDeRecursosProjeto", model);
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

            ListaProjetosModel listaModel = new ListaProjetosModel(projetos, this.servicoConfiguracao, this.calculoServico);

            return PartialView("_ListaProjetosFiltrada", listaModel); ;
        }

        [HttpGet]
        [Autorizador(Roles = "Gerente,Administrador")]
        public PartialViewResult CarregarListaDeServicosDoProjeto(int idProjeto)
        {
            Projeto projeto = this.projetoRepositorio.Buscar(idProjeto);
            if (ServicoDeAutenticacao.UsuarioLogado.Permissao != Permissao.Administrador && projeto.Gerente.Email != ServicoDeAutenticacao.UsuarioLogado.Email)
            {
                FlashMessage.Warning("Você não pode ver recursos de projetos de outros gerentes.");
                return PartialView("_ListaDeRecursosProjeto", null);
            }
            IList<ControleRecurso> controleRecurso = this.controleRecursoRepositorio.ListarServico(projeto);
            ControleRecursoListagemModel model = this.ConverterIListControleRecursoParaModel(projeto, controleRecurso);
            return PartialView("_ListaDeRecursosProjeto", model);
        }

        private ControleRecurso ConverterModelParaControleRecurso(ControleRecursoModel model)
        {
            return new ControleRecurso(0, this.projetoRepositorio.Buscar(model.IdProjeto), this.recursoRepositorio.Buscar(model.IdRecurso), model.DataInicio, model.DataFim);
        }

        private ControleRecursoListagemModel ConverterIListControleRecursoParaModel(Projeto projeto, IList<ControleRecurso> lista)
        {
            IList<ControleRecursoModel> listaControleRecursoModel = new List<ControleRecursoModel>();
            foreach (ControleRecurso controleRecurso in lista)
            {
                listaControleRecursoModel.Add(new ControleRecursoModel(controleRecurso.Recurso, controleRecurso.Projeto, controleRecurso.DataInicio, controleRecurso.DataFim));
            }
            decimal custoTotalPrevisto = calculoServico.CalcularCustoTotalAte(projeto, projeto.DataFinalPrevista);
            return new ControleRecursoListagemModel(listaControleRecursoModel, custoTotalPrevisto);
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