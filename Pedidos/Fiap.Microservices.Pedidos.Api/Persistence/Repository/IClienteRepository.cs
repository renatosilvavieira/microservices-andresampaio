using Fiap.Microservices.Pedidos.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.Microservices.Pedidos.Api.Persistence.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> Criar(Cliente cliente);
        Task<Cliente> SelecionarPorId(int id);
        Task<List<Cliente>> SelecionarTodos();
        Task Atualizar(Cliente cliente);
        Task Excluir(int id);
        Task<bool> Existe(int id);
    }
}
