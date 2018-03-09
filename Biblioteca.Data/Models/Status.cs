namespace Biblioteca.Data.Models
{
    public class Status : Base
    {
        public Status() { }

        public Status(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
    }
}