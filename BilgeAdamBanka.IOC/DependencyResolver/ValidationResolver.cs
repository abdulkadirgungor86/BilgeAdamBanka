using BilgeAdamBanka.APIMODEL.ApiModels.CreditCard;
using BilgeAdamBanka.VALIDATION.ValidatorClasses;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.IOC.DependencyResolver
{
    public static class ValidationResolver
    {
        public static void AddValidatiorServices(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddScoped<IValidator<CheckCreditCardRequestModel>, CheckCreditCardRequestMV>();
            services.AddScoped<IValidator<AddCreditCardRequestModel>, AddCreditCardRequestMV>();
            services.AddScoped<IValidator<UpdateCreditCardRequestModel>,UpdateCreditCardRequestMV>();
        }
    }
}
