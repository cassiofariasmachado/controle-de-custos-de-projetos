namespace ControleCustos.Dominio.Usuario.Interface
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorEmail(string email);
    }
}
