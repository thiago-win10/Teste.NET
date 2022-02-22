using System.ComponentModel.DataAnnotations;

namespace Teste.NET.Domain.Models
{
    public class UpdateRequest
    {
        [Required]
        [Display(Name = "Primeiro Nome")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Ultimo Nome")]
        public string LastName { get; set; }

        [Display(Name = "Nome de Usuário")]
        [Required]
        public string Username { get; set; }

        [Display(Name = "Senha")]
        [Required]
        public string Password { get; set; }

    }
}


