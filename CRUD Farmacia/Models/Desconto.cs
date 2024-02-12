using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Farmacia.Models
{
    public class Desconto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O tipo de desconto é obrigatório")]
        public TipoDesconto Tipo { get; set; }

        [Required(ErrorMessage = "O valor do desconto é obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "O valor do desconto não pode ser negativo")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data de início do desconto é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data de término do desconto é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        public bool Ativo { get; set; } = true;

        // Relacionamentos
        public int? UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }

        public virtual ICollection<Usuario>? Usuarios { get; set; }
    }

    public enum TipoDesconto
    {
        Porcentagem,
        ValorFixo
    }
}
