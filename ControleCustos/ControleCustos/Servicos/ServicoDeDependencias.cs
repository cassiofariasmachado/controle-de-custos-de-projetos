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

        public static CalculoServico MontarCalculoServico()
        {
            CalculoServico calculoServico =
                new CalculoServico(ServicoDeDependencias.MontarControleRecursoRepositorio());
            return calculoServico;
        }

        public static IProjetoRepositorio MontarProjetoRepositorio()
        {
            return new ProjetoRepositorio();
        }

        public static IRecursoRepositorio MontarRecursoRepositorio()
        {
            return new RecursoRepositorio();
        }

        public static IControleRecursoRepositorio MontarControleRecursoRepositorio()
        {
            return new ControleRecursoRepositorio();
        }

        public static ServicoDeConfiguracao MontarServicoConfiguracao()
        {
            return new ServicoDeConfiguracao();
        }
    }
}