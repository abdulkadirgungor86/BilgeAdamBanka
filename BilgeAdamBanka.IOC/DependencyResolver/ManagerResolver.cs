using BilgeAdamBanka.BLL.Managers.Abstracts;
using BilgeAdamBanka.BLL.Managers.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.IOC.DependencyResolver
{
    public static class ManagerResolver
    {
        public static void AddManagerServices(this IServiceCollection services)
        {
             services.AddScoped<IUserCardInfoManager, UserCardInfoManager>();

        }
    }
}
