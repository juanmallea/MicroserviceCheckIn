﻿using CheckIn.Domain.Model.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
