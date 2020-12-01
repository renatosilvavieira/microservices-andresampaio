using Fiap.Microservices.Produtos.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.Microservices.Produtos.Api.Persistence.Repository
{
    public interface IProdutoRepository
    {
        Task<Produto> Criar(Produto produto);
        Task<Produto> SelecionarPorId(int id);
        Task<List<Produto>> SelecionarTodos();
        Task Atualizar(Produto produto);
        Task Excluir(int id);
        Task<bool> Existe(int id);
    }
}
