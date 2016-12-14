using ControleCustos.Dominio.UsuarioDominio.Enum;

namespace ControleCustos.Dominio.UsuarioDominio.Classe
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Permissao Permissao { get; set; }
    }
}
