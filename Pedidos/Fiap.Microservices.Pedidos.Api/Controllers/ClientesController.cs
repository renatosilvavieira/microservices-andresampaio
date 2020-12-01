using Fiap.Microservices.Pedidos.Api.Models;
using Fiap.Microservices.Pedidos.Api.Persistence.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Microservices.Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(ILogger<ClientesController> logger, IClienteRepository clienteRepository)
        {
            _logger = logger;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var clientes = await _clienteRepository.SelecionarTodos();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(int id)
        {
            var cliente = await _clienteRepository.SelecionarPorId(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Cliente cliente)
        {
            var clienteCriado = await _clienteRepository.Criar(cliente);

            return CreatedAtAction(nameof(SelecionarPorId), new { id = clienteCriado.Id }, clienteCriado);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(Cliente cliente)
        {
            await _clienteRepository.Atualizar(cliente);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(Cliente cliente)
        {
            await _clienteRepository.Excluir(cliente.Id);

            return NoContent();                  
        }
    }
}
