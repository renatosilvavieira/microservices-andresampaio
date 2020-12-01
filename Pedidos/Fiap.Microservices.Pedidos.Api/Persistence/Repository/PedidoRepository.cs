using Fiap.Microservices.Pedidos.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Microservices.Pedidos.Api.Persistence.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidosDbContext _context;

        public PedidoRepository(PedidosDbContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Pedido pedido)
        {
            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Pedido> Criar(Pedido pedido)
        {
            _context.Add(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        public async Task Excluir(int id)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(c => c.Id == id);

            if (pedido != null)
            {
                _context.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Existe(int id)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(c => c.Id == id);

            return pedido != null;
        }

        public async Task<Pedido> SelecionarPorId(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.ItemsDoPedido)
                .FirstOrDefaultAsync(c => c.Id == id);

            return pedido;
        }

        public async Task<List<Pedido>> SelecionarTodos()
        {
            var pedidos = await _context.Pedidos
                .Include(p => p.ItemsDoPedido)
                .ToListAsync();

            return pedidos;
        }
    }
}
