using ControleCustos.Dominio;
using ControleCustos.Infraestrutura;
using ControleCustos.Repositorio;

namespace ControleCustos.Servicos
{
    public class ServicoDeDependencias
    {
        public static UsuarioServico MontarUsuarioServico()
        {
            UsuarioServico usuarioServico =
                new UsuarioServico(
                    new UsuarioRepositorio(),
                    new ServicoDeCriptografia());

            return usuarioServico;
        }

        public static ProjetoServico MontarProjetoServico()
        {
            ProjetoServico projetoServico =
                new ProjetoServico(new ProjetoRepositorio());
            return projetoServico;
        }
    }
}