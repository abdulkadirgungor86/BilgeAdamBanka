using AutoMapper;
using BilgeAdamBanka.MAP.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.IOC.DependencyResolver
{
    public static class MapperResolver
    {
        public static void AddMapperServices(this IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new UserCardInfoMapperProfile());
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
