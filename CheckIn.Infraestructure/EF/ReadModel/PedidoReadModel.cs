using System;
using System.Collections.Generic;

namespace CheckIn.Infraestructure.EF.ReadModel
{
    public class PedidoReadModel
    {
        public Guid Id { get; set; }
        public decimal Total { get; set; }
        public string NroPedido { get; set; }

        public ICollection<DetallePedidoReadModel> Detalle { get; set; }


    }
}
