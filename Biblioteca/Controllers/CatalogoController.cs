using System;
using System.Linq;
using Biblioteca.Data.Context;
using Biblioteca.Data.Interfaces;
using Biblioteca.Models.Biblioteca;
using Biblioteca.Models.Checkout;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly IAcervo _acervo;
        private readonly IStatus _status;
        private readonly ICliente _cliente;
        private readonly ICheckout _checkout;

        public CatalogoController(IAcervo acervo, IStatus status, ICliente cliente, ICheckout checkout)
        {
            _acervo = acervo;
            _status = status;
            _cliente = cliente;
            _checkout = checkout;
        }

        private void Inicializar()
        {
            //var id = new Guid("3C8AC136-BA12-4422-A360-49B0C913852D");
            //var status = _status.GetById(id);

            //_status.Add(DbInicializacao.InicializarStatus());
            //_acervo.Adicionar(DbInicializacao.InicializarAcervoLivro(status));
            //_acervo.Adicionar(DbInicializacao.InicializarAcervoVideo());
            _cliente.Add(DbInicializacao.InicializarCliente());
        }

        public IActionResult Index()
        {
            // Inicializar();

            var listaAcervo = _acervo.BuscarTodos()
                .Select(resultado => new AcervoIndexListarViewModel
                {
                    Id = resultado.Id,
                    ImagemUrl = resultado.ImagemUrl,
                    AutorOuDiretor = _acervo.BuscarPorAutorOuDiretor(resultado.Id),
                    CodigoDeBarras = _acervo.BuscarPorCodigoBarras(resultado.Id),
                    Titulo = resultado.Titulo,
                    Tipo = _acervo.BuscarPorTipo(resultado.Id)
                });

            var acervoIndexViewModel = new AcervoIndexViewModel()
            {
                Acervos = listaAcervo
            };

            return View(acervoIndexViewModel);
        }

        public IActionResult CheckOut(Guid id)
        {
            var acervo = _acervo.BuscarPorId(id);

            var checkoutViewModel = new CheckoutViewModel("", acervo.Titulo, id, acervo.ImagemUrl, _checkout.IsCheckedOut(id));

            return View(checkoutViewModel);
        }

        [HttpPost]
        public IActionResult PlaceCheckout(Guid AssetId, Guid LibraryCardId)
        {
            _checkout.CheckOutItem(AssetId, LibraryCardId);
            return RedirectToAction("Detalhe", new { id = AssetId });
        }

        [HttpPost]
        public IActionResult PlaceHold(Guid acerboId, Guid cartaoId)
        {
            _checkout.PlaceHold(acerboId, cartaoId);
            return RedirectToAction("Detalhe", new { id = acerboId });
        }

        public IActionResult MarkLost(Guid id)
        {
            _checkout.MarkLost(id);
            return RedirectToAction("Detalhe", new { id });
        }

        public IActionResult MarkFound(Guid id)
        {
            _checkout.MarkFound(id);
            return RedirectToAction("Detalhe", new { id });
        }

        public IActionResult CheckIn(Guid id)
        {
            return View();
        }

        public IActionResult Hold(Guid id)
        {
            var acervo = _acervo.BuscarPorId(id);

            var checkoutViewModel = new CheckoutViewModel("", acervo.Titulo, id, acervo.ImagemUrl, _checkout.IsCheckedOut(id));

            checkoutViewModel.HoldCount = _checkout.GetCurrentHolds(id).Count();

            return View(checkoutViewModel);
        }

        public IActionResult Detalhe(Guid id)
        {
            var acervo = _acervo.BuscarPorId(id);

            var currentHolds = _checkout.GetCurrentHolds(id)
                .Select(x => new AcervoReservaViewModel()
                {
                    LocalReserva = _checkout.GetCurrentHoldPlaced(x.Id).ToString("d"),
                    NomeCliente = _checkout.GetCurrentHoldPatronName(x.Id)
                });

            var acervoDetalheViewModel = new AcervoDetalheViewModel
            {
                Id = id,
                Titulo = acervo.Titulo,
                Ano = acervo.Ano,
                Custo = acervo.Custo,
                Status = acervo.Status.Nome,
                ImagemUrl = acervo.ImagemUrl,
                AutorOuDiretor = _acervo.BuscarPorAutorOuDiretor(id),
                Filial = _acervo.BuscarLocalizacaoFilial(id).Nome,
                CodigoBarras = _acervo.BuscarPorCodigoBarras(id),
                ISBN = _acervo.BuscarPorISBN(id),
                CheckoutHistoricos = _checkout.GetCheckoutHistoricos(id),
                //UltimoCheckout = _checkout.GetLatestCheckout(id),
                NomeCliente = _checkout.GetCurrentCheckoutPatron(id),
                ReservaAtual = currentHolds
            };

            return View(acervoDetalheViewModel);
        }
    }
}
