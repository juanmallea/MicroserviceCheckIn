using CheckIn.Domain.Model.Pedidos;

namespace CheckIn.Domain.Factories
{
    public interface IPedidoFactory
    {
        Pedido Create(string nroPedido);
    }
}
