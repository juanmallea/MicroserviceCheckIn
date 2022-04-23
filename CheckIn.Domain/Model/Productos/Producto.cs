using CheckIn.Domain.Model.Pedidos;
using CheckIn.Domain.Model.ValueObjects;
using CheckIn.Domain.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Model.Productos
{
    public class Producto : AggregateRoot<Guid>
    {
        public string Nombre { get; private set; }

        public PrecioValue PrecioVenta { get; private set; }

        public CantidadValue StockActual { get; private set; }

        public Producto(string nombre, PrecioValue precioVenta, CantidadValue stockActual)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            PrecioVenta = precioVenta;
            StockActual = stockActual;
        }

    }
}
