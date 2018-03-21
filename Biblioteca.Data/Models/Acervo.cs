namespace Biblioteca.Data.Models
{
    public abstract class Acervo : Base
    {
        public string Titulo { get; protected set; }
        public int Ano { get; protected set; }
        public Status Status { get; set; }
        public decimal Custo { get; protected set; }
        public string ImagemUrl { get; protected set; }
        public int Quantidade { get; protected set; }
        public virtual Filial Filial { get; protected set; }
    }
}
