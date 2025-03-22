using BilgeAdamBanka.DAL.Repositories.Abstracts;
using BilgeAdamBanka.DAL.Repositories.Concretes.EF;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.IOC.DependencyResolver
{
    public static class RepositoryResolver
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserCardInfoRepository, UserCardInfoRepository>();
        }

    }
}
