using BilgeAdamBanka.APIMODEL.ApiModels.CreditCard;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.VALIDATION.ValidatorClasses
{
    public class CheckCreditCardRequestMV : AbstractValidator<CheckCreditCardRequestModel>
    {
        public CheckCreditCardRequestMV()
        {
            RuleFor(x => x.CardUserName)
                .NotEmpty().WithMessage("Kart sahibi adı boş olamaz");

            RuleFor(x => x.CardNumber)
                .NotEmpty().WithMessage("Kart numarası boş olamaz")
                .Length(16).WithMessage("Kart numarası 16 haneli olmalıdır")
                .CreditCard().WithMessage("Kart numarası geçerli bir değer olmalıdır.");

            RuleFor(x => x.CVC)
                .NotEmpty().WithMessage("CVC boş olamaz")
                .Length(3).WithMessage("CVC 3 haneli olmalıdır");

            RuleFor(x => x.ExpiryYear)
                .NotEmpty().WithMessage("Son kullanma yılı boş olamaz")
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("Son kullanma yılı geçmiş bir yıl olamaz");
           
            RuleFor(x => x.ExpiryMonth)
                .NotEmpty().WithMessage("Son kullanma ayı boş olamaz")
                .InclusiveBetween(1, 12).WithMessage("Son kullanma ayı 1-12 arasında olmalıdır");
        }
    }
}
