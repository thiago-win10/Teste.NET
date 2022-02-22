using Domain.Models;
using FluentValidation;

namespace Domain.Validation
{
    public class ClienteEnderecoValidation : AbstractValidator<ClienteEndereco>
    {
        public ClienteEnderecoValidation()
        {
            RuleFor(m => m.Logradouro).NotEmpty().WithMessage("Campo obrigatório");
            RuleFor(m => m.Numero).NotEmpty().WithMessage("Campo obrigatório");
            RuleFor(m => m.Complemento).Null();
            RuleFor(m => m.Bairro).NotEmpty().WithMessage("Campo obrigatório");
            RuleFor(m => m.CEP).NotEmpty().WithMessage("Campo obrigatório");
            RuleFor(m => m.UF).NotEmpty().WithMessage("Campo obrigatório");

        }

    }
}


