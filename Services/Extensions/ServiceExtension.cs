﻿using System.Reflection;
using App.Services.ExceptionHandlers;
using App.Services.Products;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Services.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddExceptionHandler<CriticalExceptionHandler>();
            services.AddExceptionHandler<GenericExceptionHandler>();
        }
    }
}
