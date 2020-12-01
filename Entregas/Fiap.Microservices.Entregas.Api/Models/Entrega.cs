using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Microservices.Entregas.Api.Models
{
    public class Entrega
    {
        public int Id { get; set; }
        public DateTime DataSaida { get; set; }
        public int EntregadorId { get; set; }
        public Entregador Entregador { get; set; }
        public int PedidoId { get; set; }
        public string Endereco { get; set; }
    }
}
