using ControleCustos.Dominio.Enum;
using ControleCustos.Models;
using ControleCustos.Servicos;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControleCustos.Filtro
{
    public class Autorizador : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            UsuarioModel usuario = ServicoDeAutenticacao.UsuarioLogado;

            if (usuario == null) return false;

            string[] permissoesRequidas = this.Roles.Split(',')
                                        .Where(p => !String.IsNullOrEmpty(p))
                                        .ToArray();

            foreach (string permissao in permissoesRequidas)
            {
                if (this.TransformaPermissaoParaString(usuario.Permissao).Equals(permissao))
                {
                    return true;
                }
            }

            return false;
        }

        private string TransformaPermissaoParaString(Permissao permissao)
        {
            string retorno = null;
            switch (permissao)
            {
                case Permissao.Administrador:
                    retorno = "Administrador";
                    break;
                case Permissao.Gerente:
                    retorno = "Gerente";
                    break;
            }
            return retorno;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Controller.TempData["ErroNaoAutorizado"] = "Você não está autorizado a acessar essa página.";
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Acesso", action = "Login" }));
        }
    }
}