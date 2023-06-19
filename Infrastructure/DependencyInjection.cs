using DataLayer.Implementation;
using DataLayer.Interface;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Implementation;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddScoped<IShipmentService, ShipmentService>();
            services.AddScoped<IPaymentService, PaymentServices>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IShipmentActions, ShipmentActions>();
            services.AddScoped<IPaymentActions, PaymentActions>();
            services.AddScoped<ICartActions, CartActions>();
            services.AddScoped<ICustomerAction, CustomerAction>();
            return services;
        }
    }
}
