using ControleCustos.Dominio;
using ControleCustos.Dominio.Interface;
using ControleCustos.Filtro;
using ControleCustos.Models;
using ControleCustos.Servicos;
using System;
using System.Web.Mvc;

namespace ControleCustos.Controllers
{
    public class ProjetoController : Controller
    {
        private IProjetoRepositorio projetoRepositorio;
        private UsuarioServico usuarioServico;

        public ProjetoController()
        {
            this.projetoRepositorio = ServicoDeDependencias.MontarProjetoRepositorio();
            this.usuarioServico = ServicoDeDependencias.MontarUsuarioServico();
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

    }
}