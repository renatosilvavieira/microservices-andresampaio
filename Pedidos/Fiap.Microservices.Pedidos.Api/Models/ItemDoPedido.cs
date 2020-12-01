using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Microservices.Pedidos.Api.Models
{
    public class ItemDoPedido
    {
        public int Id { get; set; }      
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}
