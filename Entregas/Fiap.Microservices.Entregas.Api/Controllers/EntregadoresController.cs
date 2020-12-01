using Fiap.Microservices.Entregas.Api.Models;
using Fiap.Microservices.Entregas.Api.Persistence.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Microservices.Entregas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregadoresController : ControllerBase
    {
        private readonly ILogger<EntregadoresController> _logger;
        private readonly IEntregadorRepository _entregadorRepository;

        public EntregadoresController(ILogger<EntregadoresController> logger, IEntregadorRepository entregadorRepository)
        {
            _logger = logger;
            _entregadorRepository = entregadorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var entregadors = await _entregadorRepository.SelecionarTodos();

            return Ok(entregadors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(int id)
        {
            var entregador = await _entregadorRepository.SelecionarPorId(id);

            if (entregador == null)
                return NotFound();

            return Ok(entregador);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Entregador entregador)
        {
            var entregadorCriado = await _entregadorRepository.Criar(entregador);

            return CreatedAtAction(nameof(SelecionarPorId), new { id = entregadorCriado.Id }, entregadorCriado);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(Entregador entregador)
        {
            await _entregadorRepository.Atualizar(entregador);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(Entregador entregador)
        {
            await _entregadorRepository.Excluir(entregador.Id);

            return NoContent();                  
        }
    }
}
