using System;

public class Preco
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }

    // Relacionamento com Produto
    public Produto Produto { get; set; }
}