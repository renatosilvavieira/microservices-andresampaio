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
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(ILogger<PedidosController> logger, IPedidoRepository pedidoRepository)
        {
            _logger = logger;
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var pedidos = await _pedidoRepository.SelecionarTodos();

            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(int id)
        {
            var pedido = await _pedidoRepository.SelecionarPorId(id);

            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Pedido pedido)
        {
            var pedidoCriado = await _pedidoRepository.Criar(pedido);

            return CreatedAtAction(nameof(SelecionarPorId), new { id = pedidoCriado.Id }, pedidoCriado);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(Pedido pedido)
        {
            await _pedidoRepository.Atualizar(pedido);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(Pedido pedido)
        {
            await _pedidoRepository.Excluir(pedido.Id);

            return NoContent();                  
        }
    }
}
