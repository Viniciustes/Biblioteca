using System;
using System.Linq;
using Biblioteca.Data.Context;
using Biblioteca.Data.Interfaces;
using Biblioteca.Models.Biblioteca;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly IAcervo _acervo;

        public CatalogoController(IAcervo acervo)
        {
            _acervo = acervo;
        }

        private void Inicializar()
        {
            // _acervo.Adicionar(DbInicializacao.InicializarFilial());
            _acervo.Adicionar(DbInicializacao.InicializarAcervoLivro());
            _acervo.Adicionar(DbInicializacao.InicializarAcervoVideo());
        }

        public IActionResult Index()
        {
            //   Inicializar();


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
            return View();
        }

        public IActionResult MarkLost(Guid id)
        {
            return RedirectToAction("Index");
        }

        public IActionResult MarkFound(Guid id)
        {
            return View();
        }

        public IActionResult CheckIn(Guid id)
        {
            return View();
        }

        public IActionResult Hold(Guid id)
        {
            return View();
        }

        public IActionResult Detalhe(Guid id)
        {
            var acervo = _acervo.BuscarPorId(id);

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
                ISBN = _acervo.BuscarPorISBN(id)
            };

            return View(acervoDetalheViewModel);
        }
    }
}
