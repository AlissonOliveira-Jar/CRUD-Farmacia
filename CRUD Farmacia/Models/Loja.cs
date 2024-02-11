using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Farmacia.Models
{
    public class Loja
    {
        public int Id { get; set; }

        public Loja()
        {
            Nome = string.Empty;
            Endereco = string.Empty;
            Telefone = string.Empty;
        }

        [Required(ErrorMessage = "O nome da loja é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O endereço da loja é obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O telefone da loja é obrigatório")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }

        public required List<Produto> Produtos { get; set; }
    }
}
