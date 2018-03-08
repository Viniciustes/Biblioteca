using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Data.Models
{
    public class Livro : Acervo
    {
        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public string CodigoBarras { get; set; }
    }
}