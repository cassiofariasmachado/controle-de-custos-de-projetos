using ControleCustos.Dominio;
using ControleCustos.Filtro;
using ControleCustos.Models;
using ControleCustos.Servicos;
using System;
using System.Web.Mvc;

namespace ControleCustos.Controllers
{
    public class ProjetoController : Controller
    {
        private ProjetoServico projetoServico;
        private UsuarioServico usuarioServico;

        public ProjetoController()
        {
            this.projetoServico = ServicoDeDependencias.MontarProjetoServico();
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
            Console.Write(ServicoDeAutenticacao.UsuarioLogado.Email);
            if (ModelState.IsValid)
            {
                try
                {
                    Projeto salvo = ConverterModelParaProjeto(model);
                    salvo.Gerente = this.usuarioServico.BuscarPorEmail(ServicoDeAutenticacao.UsuarioLogado.Email);
                    this.projetoServico.Salvar(salvo);
                    return Json(new { Mensagem = "Cadastro efetuado com sucesso." }, JsonRequestBehavior.AllowGet);
                }
                catch (ProjetoException e)
                {
                    ModelState.AddModelError("", e.Message);
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
            return new Projeto(model.Id.GetValueOrDefault(), model.Nome, model.Cliente, model.Tecnologia, model.DataInicio,
                                    model.DataFinalPrevista, model.DataFinalRealizada.GetValueOrDefault(), model.FaturamentoPrevisto, model.NumeroProfissionais, model.Situacao);
        }

        private Usuario ConverterModelParaUsuario(UsuarioModel model)
        {
            return new Usuario(model.Id, model.Email);
        }

        private ProjetoModel CriarProjetoViewModel(Projeto projeto)
        {
            var model = new ProjetoModel(projeto);
            return model;
        }

    }
}