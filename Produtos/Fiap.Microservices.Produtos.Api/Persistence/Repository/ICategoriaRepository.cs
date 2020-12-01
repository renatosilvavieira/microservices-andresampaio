using Fiap.Microservices.Produtos.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.Microservices.Produtos.Api.Persistence.Repository
{
    public interface ICategoriaRepository
    {
        Task<Categoria> Criar(Categoria categoria);
        Task<Categoria> SelecionarPorId(int id);
        Task<List<Categoria>> SelecionarTodos();
        Task Atualizar(Categoria categoria);
        Task Excluir(int id);
        Task<bool> Existe(int id);
    }
}
