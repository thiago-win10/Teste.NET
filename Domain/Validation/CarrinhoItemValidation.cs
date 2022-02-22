using Domain.Models;
using FluentValidation;

namespace Domain.Validation
{
    public class CarrinhoItemValidation : AbstractValidator<CarrinhoItem>
    {
        public CarrinhoItemValidation()
        {
            RuleFor(m => m.Quantidade).NotEmpty();
            RuleFor(m => m.SubTotal).NotEmpty();

        }

    }
}


