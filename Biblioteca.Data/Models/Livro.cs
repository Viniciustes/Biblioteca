namespace Biblioteca.Data.Models
{
    public class Livro : Acervo
    {
        public Livro() { }

        public Livro(string titulo, int ano, Status status, decimal custo, string imagemUrl, int quantidade, Filial filial, string iSBN, string autor, string codigoBarras)
        {
            Titulo = titulo;
            Ano = ano;
            Status = status;
            Custo = custo;
            ImagemUrl = imagemUrl;
            Quantidade = quantidade;
            Filial = filial;
            ISBN = iSBN;
            Autor = autor;
            CodigoBarras = codigoBarras;
        }

        public string ISBN { get; private set; }
        public string Autor { get; private set; }
        public string CodigoBarras { get; private set; }
    }
}