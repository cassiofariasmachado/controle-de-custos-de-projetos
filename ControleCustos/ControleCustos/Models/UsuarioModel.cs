using ControleCustos.Dominio.Enum;
using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Models
{
    public class UsuarioModel
    {
        public UsuarioModel(string email, Permissao permissao)
        {
            this.Email = email;
            this.Permissao = permissao;
        }
        [Required]
        [EmailAddress]
        public string Email { get; private set; }
        public Permissao Permissao { get; private set; }
        public long Id { get; private set; }
        [Required]
        public string Senha { get; private set; }
        public string Nome { get; private set; }
    }
}