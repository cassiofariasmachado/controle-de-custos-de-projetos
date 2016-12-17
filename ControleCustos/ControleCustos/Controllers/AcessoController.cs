using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;
using ControleCustos.Models;
using ControleCustos.Servicos;
using System.Web.Mvc;
using System.Web.Security;

namespace ControleCustos.Controllers
{
    public class AcessoController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logar(string email, string senha)
        {
            if (ModelState.IsValid)
            {
                UsuarioServico usuarioServico = ServicoDeDependencias.MontarUsuarioServico();

                Usuario usuarioLogin = usuarioServico.BuscarPorAutenticacao(email, senha);

                if (usuarioLogin != null)
                {
                    ServicoDeAutenticacao.Autenticar(new UsuarioModel(usuarioLogin.Email, usuarioLogin.Permissao));

                    if (usuarioLogin.Permissao == Permissao.Administrador)
                    {
                        return RedirectToAction("ListaProjetos", "Projeto");
                    }
                    else
                    {
                        return RedirectToAction("Cadastro", "Projeto");
                    }
                }
            }
            ViewBag.MensagemErro = "Login ou senha inválidos.";
            return View("Login");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return View("Login");
        }
    }
}