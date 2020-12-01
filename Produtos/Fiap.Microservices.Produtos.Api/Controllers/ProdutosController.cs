using Fiap.Microservices.Produtos.Api.Models;
using Fiap.Microservices.Produtos.Api.Persistence.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Microservices.Produtos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ILogger<ProdutosController> _logger;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(ILogger<ProdutosController> logger, IProdutoRepository produtoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var produtos = await _produtoRepository.SelecionarTodos();

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorId(int id)
        {
            var produto = await _produtoRepository.SelecionarPorId(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Produto produto)
        {
            var produtoCriado = await _produtoRepository.Criar(produto);

            return CreatedAtAction(nameof(SelecionarPorId), new { id = produtoCriado.Id }, produtoCriado);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(Produto produto)
        {
            await _produtoRepository.Atualizar(produto);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(Produto produto)
        {
            await _produtoRepository.Excluir(produto.Id);

            return NoContent();                  
        }
    }
}
