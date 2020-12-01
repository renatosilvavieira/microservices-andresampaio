using Fiap.Microservices.Produtos.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Microservices.Produtos.Api.Persistence.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutosDbContext _context;

        public ProdutoRepository(ProdutosDbContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> Criar(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task Excluir(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            if(produto != null)
            {
                _context.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Existe(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            return produto != null;
        }

        public async Task<Produto> SelecionarPorId(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            return produto;
        }

        public async Task<List<Produto>> SelecionarTodos()
        {
            var produtos = await _context.Produtos.ToListAsync();

            return produtos;
        }
    }
}
