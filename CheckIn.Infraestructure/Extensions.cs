using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CheckIn.Application;
using CheckIn.Domain.Repositories;
using CheckIn.Infraestructure.EF;
using CheckIn.Infraestructure.EF.Contexts;
using CheckIn.Infraestructure.EF.Repository;
using System.Reflection;

namespace CheckIn.Infraestructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddApplication();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            var connectionString = 
                configuration.GetConnectionString("PedidoDbConnectionString");

            services.AddDbContext<ReadDbContext>(context => 
                context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(context => 
                context.UseSqlServer(connectionString));

            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }

    }
}
