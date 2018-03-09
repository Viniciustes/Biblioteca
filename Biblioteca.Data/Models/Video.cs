namespace Biblioteca.Data.Models
{
    public class Video : Acervo
    {
        public Video() { }

        public Video(string titulo, int ano, Status status, decimal custo, string imagemUrl, int quantidade, Filial filial, string diretor)
        {
            Titulo = titulo;
            Ano = ano;
            Status = status;
            Custo = custo;
            ImagemUrl = imagemUrl;
            Quantidade = quantidade;
            Filial = filial;
            Diretor = diretor;
        }

        public string Diretor { get; private set; }
    }
}
