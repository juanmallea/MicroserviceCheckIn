using MediatR;
using Microsoft.EntityFrameworkCore;
using CheckIn.Application.Dto.Pedido;
using CheckIn.Application.UseCases.Queries.Pedidos.GetPedidosCancelados;
using CheckIn.Infraestructure.EF.Contexts;
using CheckIn.Infraestructure.EF.ReadModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.UseCases.Queries.Pedidos
{
    public class SearchPedidosHandler : 
        IRequestHandler<SearchPedidosQuery, ICollection<PedidoDto>>
    {
        private readonly DbSet<PedidoReadModel> _pedidos;

        public SearchPedidosHandler(ReadDbContext context)
        {
            _pedidos = context.Pedido;
        }

        public async Task<ICollection<PedidoDto>> Handle(SearchPedidosQuery request, CancellationToken cancellationToken)
        {

            var pedidoList = await _pedidos
                            .AsNoTracking()
                            .Include(x => x.Detalle)
                            .ThenInclude(x => x.Producto)
                            .Where(x => x.NroPedido.Contains(request.NroPedido))
                            .ToListAsync();

            var result = new List<PedidoDto>();

            foreach (var objPedido in pedidoList)
            {
                var pedidoDto = new PedidoDto()
                {
                    Id = objPedido.Id,
                    NroPedido = objPedido.NroPedido,
                    Total = objPedido.Total
                };

                foreach (var item in objPedido.Detalle)
                {
                    pedidoDto.Detalle.Add(new DetallePedidoDto()
                    {
                        Cantidad = item.Cantidad,
                        Instrucciones = item.Instrucciones,
                        Precio = item.Precio,
                        ProductoId = item.Producto.Id
                    });
                }
                result.Add(pedidoDto);
            }

            return result;
        }
    }
}
