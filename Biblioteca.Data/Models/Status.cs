using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Data.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }
    }
}