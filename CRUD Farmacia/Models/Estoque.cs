using System.ComponentModel.DataAnnotations;

namespace CRUD_Farmacia.Models
{
    public class Estoque
    {
        [Required(ErrorMessage = "O ID do estoque é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "A loja do estoque é obrigatória")]
        public int LojaId { get; set; }

        [Required(ErrorMessage = "O produto do estoque é obrigatório")]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "A quantidade em estoque é obrigatória")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade em estoque não pode ser negativa")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "A data de entrada do produto no estoque é obrigatória")]
        public DateTime DataEntrada { get; set; }
        [Required(ErrorMessage = "A data de saída do produto no estoque é obrigatória")]
        public DateTime? DataSaida { get; set; }

        public required Loja Loja { get; set; }

        public required Produto Produto { get; set; }

        public bool EstaEmEstoque()
        {
            return Quantidade > 0;
        }

        public bool EstaDisponivelParaVenda()
        {
            return DataSaida == null && EstaEmEstoque();
        }
    }
}
