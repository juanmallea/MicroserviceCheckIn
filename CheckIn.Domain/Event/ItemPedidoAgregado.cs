﻿using CheckIn.Domain.Model.ValueObjects;
using CheckIn.Domain.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Event
{
    public record ItemPedidoAgregado : DomainEvent
    {
        public Guid ProductoId { get; }
        public PrecioValue Precio { get; }
        public CantidadValue Cantidad { get; }

        public ItemPedidoAgregado(Guid productoId, PrecioValue precio, CantidadValue cantidad) : base(DateTime.Now)
        {
            ProductoId = productoId;
            Precio = precio;
            Cantidad = cantidad;
        }
    }
}
