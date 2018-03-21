using Biblioteca.Data.Context;
using Biblioteca.Data.Interfaces;
using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Services.Services
{
    public class CheckoutService : BaseService, ICheckout
    {
        private readonly DateTime _now;

        public CheckoutService(DbContextBiblioteca dbContextBiblioteca)
        {
            _db = dbContextBiblioteca;
            _now = DateTime.Now;
        }

        public void Add(Checkout checkout)
        {
            _db.Add(checkout);
            _db.SaveChanges();
        }

        public void CheckInItem(Guid acervoId, Guid cartaoId)
        {
            var item = _db.Acervo
                .FirstOrDefault(x => x.Id == acervoId);

            RemoveExistingCheckouts(acervoId);
            CloseExistingCheckoutHistory(acervoId);

            var currentHolds = _db.Reserva
                .Include(x => x.Acervo)
                .Include(x => x.CartaoBiblioteca)
                .Where(x => x.Acervo.Id == acervoId);

            if (currentHolds.Any())
            {
                CheckoutToEarLiestHold(acervoId, currentHolds);
            }

            UpdateAssetStatus(acervoId, "Available");

            _db.SaveChanges();
        }

        private void CheckoutToEarLiestHold(Guid acervoId, IQueryable<Reserva> currentHolds)
        {
            var earliestHold = currentHolds
                .OrderBy(x => x.DtReserva)
                .FirstOrDefault();

            var card = earliestHold.CartaoBiblioteca;

            _db.Remove(earliestHold);
            _db.SaveChanges();
            CheckOutItem(acervoId, card.Id);
        }

        public bool IsCheckedOut(Guid id)
        {
            return _db.Checkout
                .Where(x => x.BibliotecaPatrimonio.Id == id)
                .Any();
        }

        public void CheckOutItem(Guid acervoId, Guid cartaoId)
        {
            if (IsCheckedOut(acervoId))
                return;

            var item = _db.Acervo
                .FirstOrDefault(x => x.Id == acervoId);

            UpdateAssetStatus(acervoId, "Checked Out");

            var libraryCard = _db.Cartao
                .Include(cart => cart.Checkouts)
                .FirstOrDefault(cart => cart.Id == cartaoId);

            var checkout = new Checkout(item, libraryCard, _now, GetDefaultCheckoutTime(_now));

            _db.Add(checkout);

            var checkoutHistory = new CheckoutHistorico(item, libraryCard, _now, GetDefaultCheckoutTime(_now));

            _db.Add(checkoutHistory);
            _db.SaveChanges();
        }

        private DateTime GetDefaultCheckoutTime(DateTime now) => now.AddDays(30);

        public IEnumerable<Checkout> GetAll()
        {
            return _db.Checkout;
        }

        public Checkout GetByID(Guid checkoutId)
        {
            return GetAll().FirstOrDefault(x => x.Id == checkoutId);
        }

        public IEnumerable<CheckoutHistorico> GetCheckoutHistoricos(Guid id)
        {
            return _db.CheckoutHistorico
                .Include(x => x.Acervo)
                .Include(x => x.Cartao)
                .Where(x => x.Acervo.Id == id);
        }

        public string GetCurrentHoldPatronName(Guid id)
        {
            var hold = _db.Reserva
                .Include(x => x.Acervo)
                .Include(x => x.CartaoBiblioteca)
                .FirstOrDefault(x => x.Id == id);

            var cardId = hold?.CartaoBiblioteca.Id;

            var patron = _db.Cliente
                .Include(x => x.Cartao)
                .FirstOrDefault(x => x.Cartao.Id == cardId);

            return patron?.Nome + " " + patron?.Sobrenome;
        }

        public DateTime GetCurrentHoldPlaced(Guid id)
        {
            return _db.Reserva
                 .Include(x => x.Acervo)
                 .Include(x => x.CartaoBiblioteca)
                 .FirstOrDefault(x => x.Id == id)
                 .DtReserva;
        }

        public IEnumerable<Reserva> GetCurrentHolds(Guid id)
        {
            return _db.Reserva
                .Include(x => x.Acervo)
                .Where(x => x.Acervo.Id == id);
        }

        public Checkout GetLatestCheckout(Guid id)
        {
            return _db.Checkout
                .Where(x => x.BibliotecaPatrimonio.Id == id)
                .OrderByDescending(x => x.DtEmprestimo)
                .FirstOrDefault();
        }

        public void MarkFound(Guid acervoId)
        {
            UpdateAssetStatus(acervoId, "Available");

            RemoveExistingCheckouts(acervoId);

            CloseExistingCheckoutHistory(acervoId);

            _db.SaveChanges();
        }

        private void UpdateAssetStatus(Guid acervoId, string newStatus)
        {
            var item = _db.Acervo
                 .FirstOrDefault(x => x.Id == acervoId);

            _db.Update(item);

            item.Status = _db.Status
                .FirstOrDefault(x => x.Nome == newStatus);
        }

        private void CloseExistingCheckoutHistory(Guid acervoId)
        {
            var historico = _db.CheckoutHistorico
                .FirstOrDefault(x => x.Acervo.Id == acervoId
                && x.DtEmprestimo == null);

            if (historico != null)
            {
                _db.Update(historico);
                historico.DtEmprestimo = _now;
            }
        }

        private void RemoveExistingCheckouts(Guid acervoId)
        {
            var checkout = _db.Checkout
                .FirstOrDefault(x => x.BibliotecaPatrimonio.Id == acervoId);

            if (checkout != null)
            {
                _db.Remove(checkout);
            }
        }

        public void MarkLost(Guid acervoId)
        {
            UpdateAssetStatus(acervoId, "Lost");
            _db.SaveChanges();
        }

        public void PlaceHold(Guid acervoId, Guid cartaoId)
        {
            var acervo = _db.Acervo
                .Include(x => x.Status)
                .FirstOrDefault(a => a.Id == acervoId);

            var card = _db.Cartao.FirstOrDefault(c => c.Id == cartaoId);

            if (acervo.Status.Nome == "Available")
                UpdateAssetStatus(acervoId, "On Hold");

            var hold = new Reserva(_now, acervo, card);
            _db.Add(hold);
            _db.SaveChanges();
        }

        public string GetCurrentCheckoutPatron(Guid acervoId)
        {
            var checkout = GetCheckoutByAssetId(acervoId);

            if (checkout == null)
                return "";

            var cardId = checkout.Cartao.Id;

            var patron = _db.Cliente
                .Include(x => x.Cartao)
                .FirstOrDefault(x => x.Cartao.Id == cardId);

            return patron.Nome + " " + patron.Sobrenome;
        }

        private Checkout GetCheckoutByAssetId(Guid acervoId)
        {
            return _db.Checkout
                 .Include(x => x.BibliotecaPatrimonio)
                 .Include(x => x.Cartao)
                 .FirstOrDefault(x => x.BibliotecaPatrimonio.Id == acervoId);
        }
    }
}
