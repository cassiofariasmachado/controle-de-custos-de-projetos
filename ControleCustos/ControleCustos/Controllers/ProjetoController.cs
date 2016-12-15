using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleCustos.Controllers
{
    public class ProjetoController : Controller
    {
        public ActionResult Cadastro()
        {
            GetListaDeSituacao();
            return View();
        }

        private void GetListaDeSituacao()
        {
            ViewData["ListaSituacao"] = new List<SelectListItem>()
            {
                new SelectListItem() { Value = "BR", Text = "Brasil" },
                new SelectListItem() { Value = "AR", Text = "Argentina" },
                new SelectListItem() { Value = "NZ", Text = "Nova Zelândia" },
                new SelectListItem() { Value = "IT", Text = "Itália" },
                new SelectListItem() { Value = "JP", Text = "Japão" },
                new SelectListItem() { Value = "RU", Text = "Mother Russia" },
                new SelectListItem() { Value = "SL", Text = "Eslovênia" },
                new SelectListItem() { Value = "GR", Text = "Grécia" },
                new SelectListItem() { Value = "US", Text = "Estados Unidos" },
                new SelectListItem() { Value = "MP", Text = "Morro da Pedra" },
                new SelectListItem() { Value = "CH", Text = "China" },
                new SelectListItem() { Value = "UK", Text = "Reino Unido" },
                new SelectListItem() { Value = "FR", Text = "França" }
            };
        }

    }
}