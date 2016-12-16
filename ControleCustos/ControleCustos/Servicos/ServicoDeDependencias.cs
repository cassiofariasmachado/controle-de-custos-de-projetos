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

        public static RecursoServico MontarRecursoServico()
        {
            return new RecursoServico(new RecursoRepositorio(), CriarServicoDeConfiguracao());
        }

        public static ProjetoServico MontarProjetoServico()
        {
            ProjetoServico projetoServico =
                new ProjetoServico(new ProjetoRepositorio());
            return projetoServico;
        }

        public static IServicoDeConfiguracao CriarServicoDeConfiguracao()
        {
            return new ServicoDeConfiguracao();
        }
    }
}