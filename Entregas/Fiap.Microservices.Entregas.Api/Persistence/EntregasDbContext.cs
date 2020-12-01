using Fiap.Microservices.Entregas.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Microservices.Entregas.Api.Persistence
{
    public class EntregasDbContext : DbContext
    {
        public EntregasDbContext(DbContextOptions<EntregasDbContext> options) : base(options) { }

        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<Entregador> Entregadores { get; set; }


    }
}
