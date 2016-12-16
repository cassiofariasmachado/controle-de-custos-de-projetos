using ControleCustos.Dominio.Criptografia.Interface;
using ControleCustos.Dominio.Interface;

namespace ControleCustos.Dominio
{
    public class UsuarioServico
    {
        private IServicoDeCriptografia servicoDeCriptografia;
        private IUsuarioRepositorio usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio, IServicoDeCriptografia servicoDeCriptografia)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.servicoDeCriptografia = servicoDeCriptografia;
        }

        public Usuario BuscarPorAutenticacao(string email, string senha)
        {
            Usuario usuarioEncontrado = this.usuarioRepositorio.BuscarPorEmail(email);

            string senhaCriptografada = this.servicoDeCriptografia.Criptografar($"$_${senha}$_$");

            if (usuarioEncontrado != null && usuarioEncontrado.Senha.Equals(senhaCriptografada))
            {
                return usuarioEncontrado;
            }

            return null;
        }

        public Usuario BuscarPorEmail(string email)
        {
            return this.usuarioRepositorio.BuscarPorEmail(email);
        }
    }
}
