using Fiap.Microservices.Entregas.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.Microservices.Entregas.Api.Persistence.Repository
{
    public interface IEntregadorRepository
    {
        Task<Entregador> Criar(Entregador entregador);
        Task<Entregador> SelecionarPorId(int id);
        Task<List<Entregador>> SelecionarTodos();
        Task Atualizar(Entregador entregador);
        Task Excluir(int id);
        Task<bool> Existe(int id);
    }
}
