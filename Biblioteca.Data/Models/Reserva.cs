using System;

namespace Biblioteca.Data.Models
{
    public class Reserva
    {
        public Guid Id { get; set; }
        public virtual Acervo Acervo { get; set; }
        public virtual Cartao CartaoBiblioteca { get; set; }
        public DateTime DtReserva { get; set; }
    }
}
