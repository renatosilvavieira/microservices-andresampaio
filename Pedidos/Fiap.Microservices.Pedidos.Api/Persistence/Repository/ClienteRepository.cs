using Fiap.Microservices.Pedidos.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Microservices.Pedidos.Api.Persistence.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PedidosDbContext _context;

        public ClienteRepository(PedidosDbContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> Criar(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task Excluir(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            if (cliente != null)
            {
                _context.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Existe(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            return cliente != null;
        }

        public async Task<Cliente> SelecionarPorId(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            return cliente;
        }

        public async Task<List<Cliente>> SelecionarTodos()
        {
            var clientes = await _context.Clientes.ToListAsync();

            return clientes;
        }
    }
}
