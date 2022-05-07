using CheckIn.Domain.Model.Pedidos;

namespace CheckIn.Domain.Factories
{
    public class PedidoFactory : IPedidoFactory
    {
        public Pedido Create(string nroPedido)
        {
            return new Pedido(nroPedido);
        }
    }
}
