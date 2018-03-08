using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Data.Models
{
    public class Checkout
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Acervo BibliotecaPatrimonio { get; set; }

        public Cartao Cartao { get; set; }

        public DateTime DtEmprestimo { get; set; }

        public DateTime DtDevolucao { get; set; }
    }
}
