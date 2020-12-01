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
    public class EntregasController : ControllerBase
    {
        private readonly ILogger<EntregasController> _logger;
        private readonly IEntregaRepository _entregaRepository;

        public EntregasController(ILogger<EntregasController> logger, IEntregaRepository entregaRepository)
        {
            _logger = logger;
            _entregaRepository = entregaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var entregas = await _entregaRepository.SelecionarTodos();

            return Ok(entregas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(int id)
        {
            var entrega = await _entregaRepository.SelecionarPorId(id);

            if (entrega == null)
                return NotFound();

            return Ok(entrega);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Entrega entrega)
        {
            var entregaCriado = await _entregaRepository.Criar(entrega);

            return CreatedAtAction(nameof(SelecionarPorId), new { id = entregaCriado.Id }, entregaCriado);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(Entrega entrega)
        {
            await _entregaRepository.Atualizar(entrega);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(Entrega entrega)
        {
            await _entregaRepository.Excluir(entrega.Id);

            return NoContent();                  
        }
    }
}
