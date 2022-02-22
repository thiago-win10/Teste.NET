using System.ComponentModel.DataAnnotations;

namespace Teste.NET.Domain.Models
{
    public class AuthenticateRequest
    {
        [Required]
        [Display(Name = "Nome de Usuario")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}
