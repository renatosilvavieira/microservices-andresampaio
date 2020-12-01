using Fiap.Microservices.Entregas.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.Microservices.Entregas.Api.Persistence.Repository
{
    public interface IEntregaRepository
    {
        Task<Entrega> Criar(Entrega entrega);
        Task<Entrega> SelecionarPorId(int id);
        Task<List<Entrega>> SelecionarTodos();
        Task Atualizar(Entrega entrega);
        Task Excluir(int id);
        Task<bool> Existe(int id);
    }
}
