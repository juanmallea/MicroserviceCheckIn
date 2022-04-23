using Microsoft.Extensions.DependencyInjection;
using CheckIn.Domain.Repositories;
using CheckIn.Infraestructure.EF;
using CheckIn.Infraestructure.EF.Repository;
using CheckIn.Infraestructure.MemoryRepository;

namespace CheckIn.Infraestructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //TODO: Eliminar despues. Solo para proposito de pruebas
            services.AddSingleton<MemoryDatabase>();

            services.AddScoped<IPedidoRepository, MemoryPedidoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }

    }
}
