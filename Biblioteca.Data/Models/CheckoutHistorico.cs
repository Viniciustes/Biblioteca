using System;

namespace Biblioteca.Data.Models
{
    public class CheckoutHistorico : Base
    {
        public CheckoutHistorico() { }

        public CheckoutHistorico(Acervo acervo, Cartao cartao, DateTime dtEmprestimo, DateTime? dtDevolucao)
        {
            Acervo = acervo;
            Cartao = cartao;
            DtEmprestimo = dtEmprestimo;
            DtDevolucao = dtDevolucao;
        }

        public Acervo Acervo { get; private set; }
        public Cartao Cartao { get; private set; }
        public DateTime DtEmprestimo { get; set; }
        public DateTime? DtDevolucao { get; private set; }
    }
}
