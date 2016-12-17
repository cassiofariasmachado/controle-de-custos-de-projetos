using ControleCustos.Dominio;
using ControleCustos.Dominio.Interface;
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

        public static IProjetoRepositorio MontarProjetoRepositorio()
        {
            return new ProjetoRepositorio();
        }

        public static IRecursoRepositorio MontarRecursoRepositorio()
        {
            return new RecursoRepositorio();
        }
    }
}