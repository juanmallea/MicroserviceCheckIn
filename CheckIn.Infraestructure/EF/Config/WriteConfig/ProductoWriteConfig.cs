using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using CheckIn.Domain.Model.Productos;
using CheckIn.Domain.Model.ValueObjects;
using CheckIn.Domain.ValueObjects;

namespace CheckIn.Infraestructure.EF.Config.WriteConfig
{
    public class ProductoWriteConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre)
                .HasMaxLength(500)
                .HasColumnName("nombre");

            var precioConverter = new ValueConverter<PrecioValue, decimal>(
                precioValue => precioValue.Value,
                precio => new PrecioValue(precio)
            );

            builder.Property(x => x.PrecioVenta)
                .HasConversion(precioConverter)
                .HasColumnName("precioVenta")
                .HasPrecision(12, 2);

            var cantidadConverter = new ValueConverter<CantidadValue, int>(
               cantidadValue => cantidadValue.Value,
               cantidad => new CantidadValue(cantidad)
           );

            builder.Property(x => x.StockActual)
                .HasConversion(cantidadConverter)
                .HasColumnName("stockActual");
        }
    }
}
