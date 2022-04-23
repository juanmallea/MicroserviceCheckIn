﻿using CheckIn.Domain.Event;
using CheckIn.Domain.Model.Pedidos.ValueObjects;
using CheckIn.Domain.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Model.Pedidos
{
    public class Pedido : AggregateRoot<Guid>
    {
        public Guid ClienteId { get; private set; }
        public NumeroPedido NroPedido { get; private set; }
        public PrecioValue Total { get; private set; }

        private readonly ICollection<DetallePedido> _detalle;

        public IReadOnlyCollection<DetallePedido> Detalle 
        { 
            get
            {
                return new ReadOnlyCollection<DetallePedido>(_detalle.ToList());
            }
        }

        private Pedido() { }

        internal Pedido(string nroPedido)
        {
            Id = Guid.NewGuid();
            NroPedido = nroPedido;
            Total = new PrecioValue(0m);
            _detalle = new List<DetallePedido>();
        }

        public void AgregarItem(Guid productoId, int cantidad, decimal precio, string instrucciones)
        {
            var detallePedido = _detalle.FirstOrDefault(x => x.ProductoId == productoId);
            if (detallePedido is null)
            {
                detallePedido = new DetallePedido(productoId, instrucciones, cantidad, precio);
                _detalle.Add(detallePedido);
            }
            else
            {
                detallePedido.ModificarPedido(cantidad, precio);
            }

            Total = Total + detallePedido.SubTotal;

            AddDomainEvent(new ItemPedidoAgregado(productoId, precio, cantidad));
        }

        public void ConsolidarPedido()
        {
            var evento = new PedidoCreado(Id, NroPedido);
            AddDomainEvent(evento);
        }
    }
}
