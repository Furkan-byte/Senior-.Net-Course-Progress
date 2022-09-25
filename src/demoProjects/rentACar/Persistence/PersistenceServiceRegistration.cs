﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                               IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => 
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("RentACarConnectionString")));
            services.AddScoped<IBrandRepository, BrandRepository>();

            return services;
        }
    }
}