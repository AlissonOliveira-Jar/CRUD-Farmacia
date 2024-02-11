using CRUD_Farmacia.Models;
using System.ComponentModel.DataAnnotations;

public class Produto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do produto é obrigatório")]
    [StringLength(100, ErrorMessage = "O nome do produto não pode ter mais de 100 caracteres")]
    public required string Nome { get; set; }

    [Required(ErrorMessage = "A descrição do produto é obrigatória")]
    [StringLength(255, ErrorMessage = "A descrição do produto não pode ter mais de 255 caracteres")]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "O preço do produto é obrigatório")]
    public required Preco Preco { get; set; }

    [Required(ErrorMessage = "A quantidade em estoque do produto é obrigatória")]
    [Range(0, int.MaxValue, ErrorMessage = "A quantidade em estoque do produto não pode ser negativa")]
    public int QuantidadeEstoque { get; set; }

    public required List<Loja> Lojas { get; set; }
}
