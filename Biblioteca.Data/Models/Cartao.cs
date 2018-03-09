using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Models
{
    public class Cartao : Base
    {
        public Cartao() { }

        public Cartao(decimal tarifa, DateTime dtGeracao, IEnumerable<Checkout> checkouts)
        {
            Tarifa = tarifa;
            DtGeracao = dtGeracao;
            Checkouts = checkouts;
        }

        public decimal Tarifa { get; private set; }
        public DateTime DtGeracao { get; private set; }
        public virtual IEnumerable<Checkout> Checkouts { get; private set; }
    }
}
