using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Microservices.Pedidos.Api.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
    }
}
