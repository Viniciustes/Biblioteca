using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Models
{
    public class Cartao
    {
        public int Id { get; set; }

        public decimal Tarifa { get; set; }
        public DateTime DtGeracao { get; set; }
        public virtual IEnumerable<Checkout> Checkouts { get; set; }
    }
}
