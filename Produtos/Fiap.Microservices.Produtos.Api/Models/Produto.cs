﻿namespace Fiap.Microservices.Produtos.Api.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
