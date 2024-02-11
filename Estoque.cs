using System;

public class Estoque
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime DataSaida { get; set; }

    // Relacionamento com Produto
    public Produto Produto { get; set; }
}