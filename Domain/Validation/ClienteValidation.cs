using Domain.Models;
using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace Domain.Validation
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(m => m.Nome).NotEmpty().WithMessage("Campo obrigatório");
            RuleFor(m => m.DataNascimento).LessThan(DateTime.Now).WithMessage("Data incorreta");

            RuleFor(m => m.Email).NotNull().WithMessage("Preencha este campo")
                .EmailAddress().WithMessage("email inválido");

            RuleFor(m => m.Email2).Null();

            RuleFor(x => x.Telefone).NotNull().WithMessage("Preencha seu Telefone")
                .Must(pass =>
                Regex.IsMatch(pass, @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("Telefone inválido");

            RuleFor(m => m.Telefone2).Null();

        }

    }
}
