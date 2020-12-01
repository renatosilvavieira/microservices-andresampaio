using Fiap.Microservices.Entregas.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Microservices.Entregas.Api.Persistence.Repository
{
    public class EntregaRepository : IEntregaRepository
    {
        private readonly EntregasDbContext _context;

        public EntregaRepository(EntregasDbContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Entrega entrega)
        {
            _context.Entry(entrega).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Entrega> Criar(Entrega entrega)
        {
            _context.Add(entrega);
            await _context.SaveChangesAsync();

            return entrega;
        }

        public async Task Excluir(int id)
        {
            var entrega = await _context.Entregas.FirstOrDefaultAsync(c => c.Id == id);

            if (entrega != null)
            {
                _context.Remove(entrega);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Existe(int id)
        {
            var entrega = await _context.Entregas.FirstOrDefaultAsync(c => c.Id == id);

            return entrega != null;
        }

        public async Task<Entrega> SelecionarPorId(int id)
        {
            var entrega = await _context.Entregas.FirstOrDefaultAsync(c => c.Id == id);

            return entrega;
        }

        public async Task<List<Entrega>> SelecionarTodos()
        {
            var entregas = await _context.Entregas.ToListAsync();

            return entregas;
        }
    }
}
