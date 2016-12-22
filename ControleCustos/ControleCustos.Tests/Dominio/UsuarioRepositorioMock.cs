using ControleCustos.Dominio.Interface;
using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;

namespace ControleCustos.Tests.Dominio
{
    public class UsuarioRepositorioMock : IUsuarioRepositorio
    {
        public Usuario BuscarPorEmail(string email)
        {
            if (email.Equals("usuario@hotmail.com"))
            {
                //senha = 123
                Usuario usuario = new Usuario(1, "Usuario", "cassio@cwi.com.br", "053523c5278f3bb59e1c56f468d71e2e", Permissao.Administrador);
                return usuario;
            }
            return null;
        }
    }
}
