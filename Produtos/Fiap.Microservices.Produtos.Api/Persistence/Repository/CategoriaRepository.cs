using Fiap.Microservices.Produtos.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Microservices.Produtos.Api.Persistence.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ProdutosDbContext _context;

        public CategoriaRepository(ProdutosDbContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Categoria> Criar(Categoria categoria)
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task Excluir(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(p => p.Id == id);

            if (categoria != null)
            {
                _context.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Existe(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(p => p.Id == id);

            return categoria != null;
        }

        public async Task<Categoria> SelecionarPorId(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(p => p.Id == id);

            return categoria;
        }

        public async Task<List<Categoria>> SelecionarTodos()
        {
            var categorias = await _context.Categorias.ToListAsync();

            return categorias;
        }
    }
}
