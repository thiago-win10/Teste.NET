
using System.ComponentModel.DataAnnotations;

namespace Teste.NET.Domain.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        [Display(Name = "Primeiro Nome")]
        public string FirstName { get; set; }

        [Display(Name = "Ultimo Nome")]
        public string LastName { get; set; }

        [Display(Name = "Nome de Usuário")]
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
