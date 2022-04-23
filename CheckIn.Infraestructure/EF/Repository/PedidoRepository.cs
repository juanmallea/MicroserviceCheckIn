using CheckIn.Domain.Model.Pedidos;
using CheckIn.Domain.Repositories;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        public Task CreateAsync(Pedido obj)
        {
            Console.WriteLine($"Insertando el pedido { obj.NroPedido }");

            return Task.CompletedTask;
        }

        public Task<Pedido> FindByIdAsync(Guid id)
        {
            Console.WriteLine($"Retornando el pedido { id }");

            return null;
        }

        public Task UpdateAsync(Pedido obj)
        {
            Console.WriteLine($"Actualizando el pedido { obj.NroPedido }");

            return Task.CompletedTask;
        }
    }
}
