using BilgeAdamBanka.APIMODEL.ApiModels.CreditCard;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.VALIDATION.ValidatorClasses
{
    public class AddCreditCardRequestMV : AbstractValidator<AddCreditCardRequestModel>
    {
        public AddCreditCardRequestMV()
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

            RuleFor(x => x.CardLimit)
                .NotEmpty().WithMessage("Kart limiti boş olamaz")
                .GreaterThan(0).WithMessage("Kart limiti 0'dan büyük olmalıdır");   

            RuleFor(x => x.Balance)
                .NotEmpty().WithMessage("Bakiye boş olamaz")
                .GreaterThanOrEqualTo(0).WithMessage("Bakiye 0'dan küçük olamaz");
        }
    }
}
