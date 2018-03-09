using System;

namespace Biblioteca.Data.Models
{
    public class Reserva : Base
    {
        public Reserva() { }

        public Reserva(DateTime dtReserva, Acervo acervo, Cartao cartaoBiblioteca)
        {
            DtReserva = dtReserva;
            Acervo = acervo;
            CartaoBiblioteca = cartaoBiblioteca;
        }

        public DateTime DtReserva { get; private set; }
        public virtual Acervo Acervo { get; private set; }
        public virtual Cartao CartaoBiblioteca { get; private set; }
    }
}
