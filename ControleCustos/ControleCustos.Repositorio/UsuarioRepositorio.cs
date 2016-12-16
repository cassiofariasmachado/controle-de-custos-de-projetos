using ControleCustos.Dominio;
using ControleCustos.Dominio.Interface;
using System.Linq;

namespace ControleCustos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public Usuario BuscarPorEmail(string email)
        {
            using (var context = new DatabaseContext())
            {
                return context.Usuario.FirstOrDefault(u => u.Email.Equals(email));
            }
        }
    }
}
