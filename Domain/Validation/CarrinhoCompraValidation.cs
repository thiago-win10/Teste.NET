using Domain.Models;
using FluentValidation;

namespace Domain.Validation
{
    public class CarrinhoCompraValidation : AbstractValidator<CarrinhoCompra>
    {
        public CarrinhoCompraValidation()
        {
            RuleFor(m => m.TotalGeral).NotEmpty();
       
        }


    }
}


