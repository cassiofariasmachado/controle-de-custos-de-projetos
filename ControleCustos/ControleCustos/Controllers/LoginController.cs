using ControleCustos.Dominio.UsuarioDominio.Classe;
using ControleCustos.Models;
using ControleCustos.Servicos;
using System.Web.Mvc;

namespace ControleCustos.Controllers
{
    public class LoginController : Controller
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
                    return RedirectToAction("Index");
                }
            }
            ViewBag.MensagemErro = "Login ou senha inválidos.";
            return View("Login");
        }
    }
}