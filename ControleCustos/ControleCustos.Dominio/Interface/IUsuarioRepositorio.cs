namespace ControleCustos.Dominio.Interface
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorEmail(string email);
    }
}
