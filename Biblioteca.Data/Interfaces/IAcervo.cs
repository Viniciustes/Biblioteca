using Biblioteca.Data.Models;
using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Interfaces
{
    public interface IAcervo
    {
        IEnumerable<Acervo> BuscarTodos();
        Acervo BuscarPorId(Guid id);

        void Adicionar(Acervo acervo);
        string BuscarPorAutorOuDiretor(Guid id);
        string BuscarPorCodigoBarras(Guid id);
        string BuscarPorTipo(Guid id);
        string BuscarPorTitulo(Guid id);
        string BuscarPorISBN(Guid id);

        Filial BuscarLocalizacaoFilial(Guid id);
    }
}