using System.Linq;
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
        public IActionResult Index()
        {
            var asservoModels = _acervo.BuscarTodos();

            var listarResultado = asservoModels
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
                Acervos = listarResultado
            };

            return View(acervoIndexViewModel);
        }
    }
}
