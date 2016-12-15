using ControleCustos.Dominio.UsuarioDominio.Enum;
using ControleCustos.Models;
using ControleCustos.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleCustos.Filtro
{
    public class Autorizador : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            UsuarioModel usuario = ServicoDeAutenticacao.UsuarioLogado;

            if (usuario == null) return false;

            if(usuario.Permissao == Permissao.Administrador)
            {
                return true;
            }

            return false;
        }
    }
}