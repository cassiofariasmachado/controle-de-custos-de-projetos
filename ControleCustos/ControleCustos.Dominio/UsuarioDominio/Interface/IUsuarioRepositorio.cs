using ControleCustos.Dominio.UsuarioDominio.Classe;

namespace ControleCustos.Dominio.UsuarioDominio.Interface
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorEmail(string email);
    }
}
