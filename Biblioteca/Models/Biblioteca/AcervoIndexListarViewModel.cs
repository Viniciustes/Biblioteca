using System;

namespace Biblioteca.Models.Biblioteca
{
    public class AcervoIndexListarViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string ImagemUrl { get; set; }
        public string AutorOuDiretor { get; set; }
        public string Tipo { get; set; }
        public string CodigoDeBarras { get; set; }
        public string Quantidade { get; set; }
    }
}
