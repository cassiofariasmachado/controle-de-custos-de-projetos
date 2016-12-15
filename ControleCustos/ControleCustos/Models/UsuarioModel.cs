using ControleCustos.Dominio.UsuarioDominio.Enum;

namespace ControleCustos.Models
{
    public class UsuarioModel
    {
        public UsuarioModel(string email, Permissao permissao)
        {
            this.Email = email;
            this.Permissao = permissao;
        }
        public string Email { get; private set; }
        public Permissao Permissao { get; private set; }
        public long Id { get; private set; }
        public string Senha { get; private set; }
    }
}