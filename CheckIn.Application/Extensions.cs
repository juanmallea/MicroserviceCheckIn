using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CheckIn.Application.Services;
using CheckIn.Domain.Factories;
using System.Reflection;

namespace CheckIn.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IPedidoFactory, PedidoFactory>();



            return services;
        }

    }
}
