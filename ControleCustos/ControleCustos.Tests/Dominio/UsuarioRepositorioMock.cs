using ControleCustos.Dominio.Interface;
using ControleCustos.Dominio;

namespace ControleCustos.Tests.Dominio
{
    public class UsuarioRepositorioMock : IUsuarioRepositorio
    {
        public Usuario BuscarPorEmail(string email)
        {
            if (email.Equals("usario@hotmail.com"))
            {
                Usuario usuario = new Usuario();
                //usuario.Senha = "202cb962ac59075b964b07152d234b70";//123
                return usuario;
            }
            return null;
        }
    }
}
