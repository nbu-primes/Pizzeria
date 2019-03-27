using Microsoft.Extensions.DependencyInjection;
using Pizzeria.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.DataServices
{
    public static class DataServicesConfiguration
    {
        public static void AddCustomDataServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
