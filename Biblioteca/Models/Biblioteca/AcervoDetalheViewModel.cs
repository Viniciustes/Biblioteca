using Biblioteca.Data.Models;
using System;
using System.Collections.Generic;

namespace Biblioteca.Models.Biblioteca
{
    public class AcervoDetalheViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string AutorOuDiretor { get; set; }
        public string Tipo { get; set; }
        public int Ano { get; set; }
        public string ISBN { get; set; }
        public string CodigoBarras { get; set; }
        public string Status { get; set; }
        public decimal Custo { get; set; }
        public string Filial { get; set; }
        public string ImagemUrl { get; set; }
        public string NomeCliente { get; set; }
        public Checkout UltimoCheckout { get; set; }
        public IEnumerable<CheckoutHistorico> CheckoutHistoricos { get; set; }
        public IEnumerable<AcervoReservaViewModel> ReservaAtual { get; set; }
    }


}
