using Biblioteca.Data.Context;
using Biblioteca.Data.Interfaces;
using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Services.Services
{
    public class AcervoService : BaseService, IAcervo
    {
        public AcervoService(DbContextBiblioteca dbContextBiblioteca)
        {
            _db = dbContextBiblioteca;
        }

        public void Adicionar(Acervo acervo)
        {
            _db.Add(acervo);
            _db.SaveChanges();
        }

        public IEnumerable<Acervo> BuscarTodos()
        {
            return _db.Acervo
                .Include(a => a.Status)
                .Include(a => a.Filial);
        }

        public string BuscarPorAutorOuDiretor(Guid id)
        {
            var ehLivro = _db.Acervo.OfType<Livro>().Where(a => a.Id == id).Any();
            var ehVideo = _db.Acervo.OfType<Video>().Where(a => a.Id == id).Any();

            return ehLivro ? _db.Livro.FirstOrDefault(a => a.Id == id).Autor : _db.Video.FirstOrDefault(a => a.Id == id).Diretor ?? string.Empty;
        }

        public string BuscarPorCodigoBarras(Guid id)
        {
            if (_db.Livro.Any(a => a.Id == id))
                return _db.Livro.FirstOrDefault(a => a.Id == id).CodigoBarras;
            else
                return string.Empty;
        }

        public string BuscarPorISBN(Guid id)
        {
            if (_db.Livro.Any(a => a.Id == id))
                return _db.Livro.FirstOrDefault(a => a.Id == id).ISBN;
            else
                return string.Empty;
        }

        public string BuscarPorTipo(Guid id)
        {
            var livro = _db.Acervo.OfType<Livro>().Where(a => a.Id == id);
            return livro.Any() ? "Livro" : "Video";
        }

        public Acervo BuscarPorId(Guid id) => BuscarTodos().FirstOrDefault(a => a.Id == id);

        public string BuscarPorTitulo(Guid id) => _db.Acervo.FirstOrDefault(a => a.Id == id).Titulo;

        public Filial BuscarLocalizacaoFilial(Guid id) => _db.Acervo.FirstOrDefault(a => a.Id == id).Filial;
    }
}
