using ControleCustos.Dominio.Enum;

namespace ControleCustos.Dominio
{
    public class Usuario
    {
        public long Id { get; private set; }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public Permissao Permissao { get; private set; }

        public Usuario()
        {

        }

        public Usuario(long id, string nome, string email, string senha, Permissao permissao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Permissao = permissao;
        }
    }
}
