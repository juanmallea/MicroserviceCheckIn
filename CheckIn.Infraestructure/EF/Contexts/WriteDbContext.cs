using Microsoft.EntityFrameworkCore;
using CheckIn.Domain.Event;
using CheckIn.Domain.Model.Pedidos;
using CheckIn.Domain.Model.Productos;
using CheckIn.Infraestructure.EF.Config.WriteConfig;
using ShareKernel.Core;

namespace CheckIn.Infraestructure.EF.Contexts
{
    public class WriteDbContext : DbContext
    {
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var pedidoConfig = new PedidoWriteConfig();
            modelBuilder.ApplyConfiguration<Pedido>(pedidoConfig);
            modelBuilder.ApplyConfiguration<DetallePedido>(pedidoConfig);

            var productoConfig = new ProductoWriteConfig();
            modelBuilder.ApplyConfiguration<Producto>(productoConfig);


            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<PedidoCreado>();
            modelBuilder.Ignore<ItemPedidoAgregado>();
        }
    }
}
