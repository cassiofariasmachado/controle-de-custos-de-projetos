using ControleCustos.Dominio.UsuarioDominio.Interface;
using System.Linq;
using ControleCustos.Dominio.UsuarioDominio.Classe;

namespace ControleCustos.Repositorio.UsuarioRepositorio
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
