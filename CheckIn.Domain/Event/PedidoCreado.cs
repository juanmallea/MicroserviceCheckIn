using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Domain.Event
{
    public record PedidoCreado : DomainEvent
    {
        public Guid PedidoId { get;  }
        public string NroPedido { get; }

        public PedidoCreado(Guid pedidoId,
            string nroPedido) : base(DateTime.Now)
        {
            PedidoId = pedidoId;
            NroPedido = nroPedido;

        }
    }
}
