using Biblioteca.Data.Models;
using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Interfaces
{
    public interface ICheckout
    {
        void Add(Checkout checkout);

        IEnumerable<Checkout> GetAll();
        IEnumerable<Reserva> GetCurrentHolds(Guid id);
        IEnumerable<CheckoutHistorico> GetCheckoutHistoricos(Guid id);

        Checkout GetByID(Guid checkoutId);
        Checkout GetLatestCheckout(Guid id);

        bool IsCheckedOut(Guid id);
        DateTime GetCurrentHoldPlaced(Guid id);
        string GetCurrentHoldPatronName(Guid id);
        string GetCurrentCheckoutPatron(Guid acervoId);

        void MarkLost(Guid acervoId);
        void MarkFound(Guid acervoId);
        void PlaceHold(Guid acervoId, Guid cartaoId);
        void CheckInItem(Guid acervoId, Guid cartaoId);
        void CheckOutItem(Guid acervoId, Guid cartaoId);
    }
}
