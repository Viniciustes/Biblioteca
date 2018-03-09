using System;

namespace Biblioteca.Data.Models
{
    public class Checkout : Base
    {
        public Checkout() { }

        public Checkout(Acervo bibliotecaPatrimonio, Cartao cartao, DateTime dtEmprestimo, DateTime dtDevolucao)
        {
            BibliotecaPatrimonio = bibliotecaPatrimonio;
            Cartao = cartao;
            DtEmprestimo = dtEmprestimo;
            DtDevolucao = dtDevolucao;
        }

        public Acervo BibliotecaPatrimonio { get; private set; }
        public Cartao Cartao { get; private set; }
        public DateTime DtEmprestimo { get; private set; }
        public DateTime DtDevolucao { get; private set; }
    }
}
