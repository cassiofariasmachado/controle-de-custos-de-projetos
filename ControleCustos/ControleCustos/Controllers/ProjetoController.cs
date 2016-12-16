using ControleCustos.Dominio;
using ControleCustos.Models;
using ControleCustos.Servicos;
using System.Web.Mvc;

namespace ControleCustos.Controllers
{
    public class ProjetoController : Controller
    {
        private ProjetoServico projetoServico;

        public ProjetoController()
        {
            this.projetoServico = ServicoDeDependencias.MontarProjetoServico();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Salvar(ProjetoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Projeto salvo = ConverterModelParaProjeto(model);
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

        private ProjetoModel CriarProjetoViewModel(Projeto projeto)
        {
            var model = new ProjetoModel(projeto);
            return model;
        }

    }
}