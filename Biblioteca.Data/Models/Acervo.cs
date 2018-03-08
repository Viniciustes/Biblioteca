using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Data.Models
{
    public class Acervo
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public decimal Custo { get; set; }

        public string ImagemUrl { get; set; }

        public int Quantidade { get; set; }

        public virtual Filial Filial { get; set; }
    }
}
