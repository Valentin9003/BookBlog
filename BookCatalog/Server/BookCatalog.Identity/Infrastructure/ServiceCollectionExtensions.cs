﻿using BookCatalog.Common.Services;
using BookCatalog.Identity.Data;
using BookCatalog.Identity.Data.Models;
using BookCatalog.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


namespace BookCatalog.Identity.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserStorage(
           this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<IdentityDbContext>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services) =>
                  services.AddTransient<IDataSeeder, IdentityDataSeeder>()
                          .AddTransient<IIdentityService, IdentityService>()
                          .AddTransient<ITokenGeneratorService, TokenGeneratorService>();
    }
}
