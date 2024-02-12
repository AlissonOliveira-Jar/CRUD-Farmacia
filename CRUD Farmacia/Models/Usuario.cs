using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Farmacia.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do usuário não pode ter mais de 100 caracteres")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O CPF do usuário é obrigatório")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "O CPF do usuário deve conter apenas números")]
        public required string Cpf { get; set; }


        [Phone(ErrorMessage = "O telefone do usuário não é válido")]
        public string? Telefone { get; set; }

        // Relação muitos para muitos com Desconto
        public virtual ICollection<Desconto>? Descontos { get; set; }
    }
}