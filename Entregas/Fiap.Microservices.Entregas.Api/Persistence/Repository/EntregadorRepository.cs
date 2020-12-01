using Fiap.Microservices.Entregas.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Microservices.Entregas.Api.Persistence.Repository
{
    public class EntregadorRepository : IEntregadorRepository
    {
        private readonly EntregasDbContext _context;

        public EntregadorRepository(EntregasDbContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Entregador entregador)
        {
            _context.Entry(entregador).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Entregador> Criar(Entregador entregador)
        {
            _context.Add(entregador);
            await _context.SaveChangesAsync();

            return entregador;
        }

        public async Task Excluir(int id)
        {
            var entregador = await _context.Entregadores.FirstOrDefaultAsync(c => c.Id == id);

            if (entregador != null)
            {
                _context.Remove(entregador);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Existe(int id)
        {
            var entregador = await _context.Entregadores.FirstOrDefaultAsync(c => c.Id == id);

            return entregador != null;
        }

        public async Task<Entregador> SelecionarPorId(int id)
        {
            var entregador = await _context.Entregadores.FirstOrDefaultAsync(c => c.Id == id);

            return entregador;
        }

        public async Task<List<Entregador>> SelecionarTodos()
        {
            var entregadores = await _context.Entregadores.ToListAsync();

            return entregadores;
        }
    }
}
