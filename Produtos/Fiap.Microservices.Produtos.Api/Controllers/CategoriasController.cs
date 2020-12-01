using Fiap.Microservices.Produtos.Api.Models;
using Fiap.Microservices.Produtos.Api.Persistence.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Microservices.Categorias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ILogger<CategoriasController> _logger;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController(ILogger<CategoriasController> logger, ICategoriaRepository categoriaRepository)
        {
            _logger = logger;
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var categorias = await _categoriaRepository.SelecionarTodos();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(int id)
        {
            var categoria = await _categoriaRepository.SelecionarPorId(id);

            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Categoria categoria)
        {
            var categoriaCriado = await _categoriaRepository.Criar(categoria);

            return CreatedAtAction(nameof(SelecionarPorId), new { id = categoriaCriado.Id }, categoriaCriado);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(Categoria categoria)
        {
            await _categoriaRepository.Atualizar(categoria);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(Categoria categoria)
        {
            await _categoriaRepository.Excluir(categoria.Id);

            return NoContent();
        }
    }
}
