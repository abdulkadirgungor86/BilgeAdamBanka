using BilgeAdamBanka.APIMODEL.ApiModels.CreditCard;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.VALIDATION.ValidatorClasses
{
    public class UpdateCreditCardRequestMV : AbstractValidator<UpdateCreditCardRequestModel>
    {
        public UpdateCreditCardRequestMV()
        {
            RuleFor(x => x.CardNumber)
                .NotEmpty().WithMessage("Kart numarası boş olamaz")
                .Length(16).WithMessage("Kart numarası 16 haneli olmalıdır")
                .CreditCard().WithMessage("Kart numarası geçerli bir değer olmalıdır.");
        }
    }
}
