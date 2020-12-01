using Fiap.Microservices.Pedidos.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.Microservices.Pedidos.Api.Persistence.Repository
{
    public interface IPedidoRepository
    {
        Task<Pedido> Criar(Pedido pedido);
        Task<Pedido> SelecionarPorId(int id);
        Task<List<Pedido>> SelecionarTodos();
        Task Atualizar(Pedido pedido);
        Task Excluir(int id);
        Task<bool> Existe(int id);
    }
}
