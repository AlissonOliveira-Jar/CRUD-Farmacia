using System.ComponentModel.DataAnnotations;

namespace CRUD_Farmacia.Models
{
    public class Preco
    {
        public int Id { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Valor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        // Relacionamento com Produto
        [Required]
        public required Produto Produto { get; set; }
    }
}
